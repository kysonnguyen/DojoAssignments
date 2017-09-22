# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models
import re
import bcrypt
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')
# Create your models here.
class UserManager(models.Manager):
    def create_user(self, info):
        errors = []
        fname = info['first_name']
        lname = info['last_name']
        email = info['email']
        pw = info['password']
        if len(fname) < 2 or len(lname) < 2:
            errors.append("Name fields must have 2 or more characters each")
        if not fname.isalpha or not lname.isalpha:
            errors.append("Name fields must contain only letters")
        if not EMAIL_REGEX.match(email):
            errors.append("Please input a valid email address")
        if len(pw) < 8:
            errors.append("Password must be at least 8 characters long")
        if pw != info['confirm']:
            errors.append("Passwords must match")
        if errors:
            return[False, errors]
        else:
            user = User(first_name = fname, last_name = lname, email = email, password = pw)
            user.save()
            return[True, user]

    def login(self, info):
        errors = []
        email = info['email']
        try:
            user = User.objects.get(email = email)
        except User.DoesNotExist:
            errors.append("Please put in a valid email")
        if not user.password == info['password']:
            errors.append('Email and password do not match')
        if errors:
            return[False, errors]
        else:
            return[True, user]

class SecretManager(models.Manager):
    def create_secret(self, info):
        errors = []
        if len(info['secret']) < 1:
            errors.append('Secret cannot be empty')
        if errors:
            return[False, errors]
        else:
            secret = Secret.objects.create(secret = info['secret'], user = User.objects.get(id = info['user_id']))
            return[True, secret]

class User(models.Model):
    first_name = models.CharField(max_length = 100)
    last_name = models.CharField(max_length = 100)
    email = models.EmailField(max_length = 254)
    password = models.CharField(max_length = 1000)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    objects = UserManager()

class Secret(models.Model):
    secret = models.TextField()
    user = models.ForeignKey(User, related_name = "secrets")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    def liked_users(self):
        return User.objects.filter(likes__secret = self)

    objects = SecretManager()

class Like(models.Model):
    user = models.ForeignKey(User, related_name = "likes")
    secret = models.ForeignKey(Secret, related_name = "likes")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
