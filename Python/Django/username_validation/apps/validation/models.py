# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.
class UserManager(models.Manager):
    def create_user(self, info):
        name = info['name']
        if len(name) < 9 or len(name) > 15:
            error = "Username should be from 9 to 15 characters long."
            return[False, error]
        else:
            user = User.objects.create(name = name)
            return[True, user]
class User(models.Model):
    name = models.CharField(max_length = 16)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    objects = UserManager()
