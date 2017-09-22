# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse
from datetime import datetime

# Create your views here.
def index(request):

    clock = {
        'date_time': datetime.now() 
    }
    return render(request, 'time_display/index.html', clock)
