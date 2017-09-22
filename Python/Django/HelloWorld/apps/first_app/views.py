# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse

def index(request):
    print "hello world"
    return render(request, 'first_app/index.html')
# Create your views here.
