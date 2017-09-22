# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.contrib import messages
from django.shortcuts import render, redirect

from .models import Course
# Create your views here.
def index(request):
    context = {
        'courses': Course.objects.all()
    }
    return render(request, 'courses/index.html', context)

def create(request):
    process = Course.objects.course_create(request.POST)
    if process[0] == False:
        for error in process[1]:
            messages.error(request, error)
    return redirect('/')

def delete(request, id):
    context = {
        'course': Course.objects.get(id=id),
    }
    return render(request,'courses/delete.html', context)

def delete_confirm(request, id):
    Course.objects.get(id = id).delete()
    return redirect('/')
