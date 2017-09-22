# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect

# Create your views here.
def index(request):
    return render(request, 'survey_form/index.html')
def process(request):
    request.session['name'] = request.POST['name']
    request.session['location'] = request.POST['location']
    request.session['language'] = request.POST['language']
    request.session['comment'] = request.POST['comment']
    if 'submission' not in request.session:
        request.session['submission'] = 0
    request.session['submission'] += 1
    return redirect('/result')
def result(request):
    return render(request, 'survey_form/result.html')
