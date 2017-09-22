# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
import random
import datetime
# Create your views here.
def index(request):
    if 'gold' not in request.session:
        request.session['gold'] = 0
        request.session['change'] = []
    return render(request, 'ninja_gold/index.html')

def process_money(request):
    building = request.POST['building']
    if building == 'farm':
        start = 10
        stop = 21
    elif building == 'cave':
        start = 5
        stop = 11
    elif building == 'house':
        start = 2
        stop = 6
    elif building == 'casino':
        start = -50
        stop = 51
    gold = random.randrange(start, stop)
    time = datetime.datetime.today().strftime("%Y-%m-%d %H:%M:%S")
    change = {
        'gold': gold,
        'building': building,
        'time': time
    }
    request.session['gold'] += gold
    request.session['change'].append(change)
    return redirect('/')

def reset(request):
    request.session.clear()
    return redirect('/')
