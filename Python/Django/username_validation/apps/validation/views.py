# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.contrib import messages
from django.shortcuts import render, redirect
from .models import User
# Create your views here.
def index(request):
    return render(request, 'validation/index.html')

def create(request):
    process = User.objects.create_user(request.POST)
    if process[0] == False:
        messages.error(request, process[1])
        return redirect ('/')
    else:

        success = "The user name you enteredc " + process[1].name + " is valid. Thank You!"
        messages.success(request, success)
        context = {
            'users': User.objects.all()
        }
        return render(request, 'validation/success.html', context)
        # return render(request, 'validation/success.html')
