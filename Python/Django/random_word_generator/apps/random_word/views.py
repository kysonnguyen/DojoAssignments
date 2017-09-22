# -*- coding: utf-8 -*-
from __future__ import unicode_literals
import random
import string
#
from django.shortcuts import render, redirect
# Create your views here.
def index(request):
    if 'attempt' not in request.session:
        request.session['attempt'] = 1
    request.session['rw'] = ''.join(random.choice(string.ascii_uppercase + string.digits) for _ in range(14))
    return render(request, 'random_word/index.html')

def generate(request):
    request.session['attempt'] += 1
    return redirect('/')
