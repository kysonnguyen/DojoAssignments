# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
from .models import User
from django.contrib import messages
# Create your views here.

def index(request):
    return render(request, "login_reg/index.html")

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
        return redirect('/success')

def login(request):
    process = User.objects.login(request.POST)
    if not process[0]:
        for error in process[1]:
            messages.add_message(request, messages.ERROR, error)
        return redirect('/')
    else:
        request.session['user_id'] = process[1].id
        request.session['status'] = "logged in"
        return redirect ('/success')

def success(request):
    user = User.objects.get(id = request.session['user_id'])
    print user
    context = {
        'user' : user.first_name,
        'status' : request.session['status']
    }
    return render(request, "login_reg/success.html", context)
