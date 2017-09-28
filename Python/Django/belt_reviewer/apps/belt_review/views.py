from __future__ import unicode_literals

from django.shortcuts import render, redirect
from .models import User, Book, Author, Review
from django.contrib import messages
from django.db.models import Count
# Create your views here.

def index(request):
    return render(request, "belt_review/index.html")

def register(request):
    process = User.objects.create_user(request.POST)
    if not process[0]:
        for error in process[1]:
            messages.add_message(request, messages.ERROR, error)
        return redirect('/')
    else:
        request.session['user_id'] = process[1].id
        request.session['name'] = process[1].first_name
        return redirect('/books')

def login(request):
    process = User.objects.login(request.POST)
    if not process[0]:
        for error in process[1]:
            messages.add_message(request, messages.ERROR, error)
        return redirect('/')
    else:
        request.session['user_id'] = process[1].id
        print request.session['user_id']
        request.session['status'] = "logged in"
        return redirect ('/books')

def logout(request):
    request.session.clear()
    return redirect('/')

def books(request):
    # create a list of ids of books in the most recent reviews
    reviews = Review.objects.order_by('-created_at')[0:3]
    book_ids = []
    for review in reviews:
        book_ids.append(review.book.id)

    # create a list of ids of books in reviews that are not in the most recent reviews
    other_reviews = Review.objects.exclude(review = reviews)
    other_book_ids = []
    for other_review in other_reviews:
        other_book_ids.append(other_review.book.id)
    #compare to create a list of ids for books that are not in the recent reviews
    s = set(book_ids)
    side_book_ids = [x for x in other_book_ids if x not in s]
    #Finally - query for books that are not in the most recent reviews
    side_books = []
    if side_book_ids:
        for i in side_book_ids:
            side_books.append(Book.objects.get(id=i))

    context ={
        'user' : User.objects.get(id = request.session['user_id']),
        'user_id': request.session['user_id'],
        'side_books':side_books,
        'reviews': Review.objects.order_by('-created_at')[0:3],
    }
    return render(request, "belt_review/books.html", context)

def add_page(request):
    context = {
        'authors': Author.objects.all()
    }
    return render(request, "belt_review/add.html", context)

def add(request):
    process = Book.objects.add_check(request.POST,request)
    if not process[0]:
        for error in process[1]:
            messages.add_message(request, messages.ERROR, error)
        return redirect ('/books/add')
    else:
        print process[1].id
        return redirect ('/books/{}'.format(process[1].id))

def add_review(request):
    process = Review.objects.add_review_only(request.POST, request)
    if not process[0]:
        for error in process[1]:
            messages.add_message(request, messages.ERROR, error)
        return redirect ('/books/{}'.format(request.POST['book_id']))
    else:
        return redirect ('/books/{}'.format(request.POST['book_id']))
def book(request, id):
    context = {
        'user' : User.objects.get(id = request.session['user_id']),
        'book' : Book.objects.get(id = id),
        'reviews' : Review.objects.filter(book__id = id).order_by('-created_at'),
        'authors' : Author.objects.filter(book__id = id).order_by('name')
    }
    return render(request, "belt_review/book.html", context)

def delete_review(request, id):
    Review.objects.get(id=id).delete()
    return redirect('/books')


def user(request, id):
    user = User.objects.get(id = id)
    reviews = Review.objects.filter(user=user)
    context = {
        'user' : user,
        'reviews': reviews,
        'count': reviews.count(),
    }

    return render(request, 'belt_review/user.html', context)
