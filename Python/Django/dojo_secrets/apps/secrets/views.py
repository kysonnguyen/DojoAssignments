from __future__ import unicode_literals

from django.shortcuts import render, redirect
from .models import User, Secret, Like
from django.contrib import messages
from django.db.models import Count
# Create your views here.

def index(request):
    return render(request, "secrets/index.html")

def register(request):
    process = User.objects.create_user(request.POST)
    if not process[0]:
        for error in process[1]:
            messages.add_message(request, messages.ERROR, error)
        return redirect('/')
    else:
        request.session['user_id'] = process[1].id
        request.session['name'] = process[1].first_name
        request.session['status'] = "registered"
        return redirect('/secrets')

def login(request):
    process = User.objects.login(request.POST)
    if not process[0]:
        for error in process[1]:
            messages.add_message(request, messages.ERROR, error)
        return redirect('/')
    else:
        request.session['user_id'] = process[1].id
        request.session['status'] = "logged in"
        return redirect ('/secrets')

def logout(request):
    request.session.clear()
    return redirect('/')

def secrets(request):
    context = {
        'user' : User.objects.get(id = request.session['user_id']),
        'user_id': request.session['user_id'],
        'secrets': Secret.objects.order_by('-created_at')[0:10]
    }
    return render(request, "secrets/secrets.html", context)

def post(request):
    process = Secret.objects.create_secret(request.POST)
    if not process[0]:
        for error in process[1]:
            messages.add_message(request, messages.ERROR, error)
        return redirect ('/secrets')
    else:
        return redirect ('/secrets')

def delete_secret(request):
    Secret.objects.get(id=request.POST['secret_id']).delete()
    return redirect('/secrets')

def like(request):
    Like.objects.create(user = User.objects.get(id=request.session['user_id']), secret = Secret.objects.get(id=request.POST['secret_id']))
    return redirect('/secrets')

def popular(request):
    context = {
        'user' : User.objects.get(id = request.session['user_id']),
        'secrets': Secret.objects.filter().annotate(num_likes=Count('likes')).order_by('-num_likes')
    }
    return render(request, 'secrets/popular.html', context)
