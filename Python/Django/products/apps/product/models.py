# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.
class Product(models.Model):
    name = models.CharField (max_length = 100)
    description = models.CharField (max_length = 200)
    weight = models.DecimalField (max_digits = 10, decimal_places = 2)
    price = models.DecimalField (max_digits = 10, decimal_places = 2)
    cost = models.DecimalField (max_digits = 10, decimal_places = 2)
    category = models.CharField (max_length = 200)
    created_at = models.DateTimeField (auto_now_add=True)
    updated_at = models.DateTimeField (auto_now=True)
