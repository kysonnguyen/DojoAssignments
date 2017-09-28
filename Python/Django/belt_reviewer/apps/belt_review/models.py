# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models
import re
import bcrypt
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')
# Create your models here.
class UserManager(models.Manager):
    def create_user(self, info):
        errors = []
        fname = info['first_name']
        lname = info['last_name']
        email = info['email']
        pw = info['password']
        if len(fname) < 2 or len(lname) < 2:
            errors.append("Name fields must have 2 or more characters each")
        if not fname.isalpha or not lname.isalpha:
            errors.append("Name fields must contain only letters")
        if not EMAIL_REGEX.match(email):
            errors.append("Please input a valid email address")
        if len(pw) < 8:
            errors.append("Password must be at least 8 characters long")
        if pw != info['confirm']:
            errors.append("Passwords must match")
        if errors:
            return[False, errors]
        else:
            user = User(first_name = fname, last_name = lname, email = email, password = pw)
            user.save()
            return[True, user]

    def login(self, info):
        errors = []
        email = info['email']
        try:
            user = User.objects.get(email = email)
        except User.DoesNotExist:
            errors.append("Please put in a valid email")
        if not user.password == info['password']:
            errors.append('Email and password do not match')
        if errors:
            return[False, errors]
        else:
            return[True, user]

class AddManager(models.Manager):
    def add_check(self, info, request):
        errors = []
        if len(info['title']) < 1:
            errors.append('Please enter a title')
        if len(info['author']) < 1 and len(info['new_author']) <1:
            errors.append('Please select or enter an author name')
        if len(info['review']) < 1:
            errors.append('Review cannot be empty')
        if errors:
            return[False, errors]
        else:
            book = Book.objects.get_or_create(title = info['title'])
            if len(info['author']) > 0:
                author = Author.objects.get_or_create(name = info['author'])
                author[0].book.add(book[0])
                author[0].save()
            if len(info['new_author']) > 0:
                new_author = Author.objects.get_or_create(name = info['new_author'])
                new_author[0].book.add(book[0])
                new_author[0].save()
            review = Review.objects.create(review = info['review'], rating = info['rating'], user = User.objects.get(id = request.session['user_id']), book = book[0] )
            return[True, book[0]]
    def add_review_only(self, info, request):
        errors = []
        if len(info['review']) < 1:
            errors.append('Review cannot be empty')
            return[False,errors]
        else:
            review = Review.objects.create(review = info['review'], rating = info['rating'], user = User.objects.get(id = request.session['user_id']), book = Book.objects.get(id=info['book_id']))
            return[True, review]
class User(models.Model):
    first_name = models.CharField(max_length = 100)
    last_name = models.CharField(max_length = 100)
    email = models.EmailField(max_length = 254)
    password = models.CharField(max_length = 1000)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    objects = UserManager()

class Book(models.Model):
    title = models.CharField(max_length = 200)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    objects = AddManager()

class Author(models.Model):
    name = models.CharField(max_length=200)
    book = models.ManyToManyField(Book, related_name="authors")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = AddManager()



class Review(models.Model):
    review = models.TextField()
    rating = models.IntegerField()
    user = models.ForeignKey(User, related_name = "reviews")
    book = models.ForeignKey(Book, related_name = "reviews", null=True)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    objects = AddManager()
