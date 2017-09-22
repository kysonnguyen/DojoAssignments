# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect

# Create your views here.
def index(request):
    return render(request, "ninja/index.html")

def show (request, color):
    context = {
        'ninjas': []
    }
    turtles = {
        'blue': ['Leonardo', 'ninja/images/leonardo.jpg'],
        'purple': ['Donatello', 'ninja/images/donatello.jpg'],
        'orange': ['Michelangelo', 'ninja/images/michelangelo.jpg'],
        'red': ['Raphael', 'ninja/images/raphael.jpg']
    }
    april = ['Megan Fox', 'ninja/images/megan_fox.jpg']
    if color == "":
        for ninja_turtle in turtles:
            context['ninjas'].append(turtles[ninja_turtle])
    elif color in turtles:
        context['ninjas'].append(turtles[color])
    else:
        context['ninjas'].append(april)
    print context['ninjas']
    return render(request, 'ninja/ninja.html', context)
