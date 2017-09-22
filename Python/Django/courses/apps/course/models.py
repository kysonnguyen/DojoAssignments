# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.
class CourseManager(models.Manager):
    def course_create(self, info):
        errors = []
        name = info['name']
        description = info['description']
        if len(name) < 3:
            errors.append("Name must have at least 3 characters")
        if len(description) < 10:
            errors.append("Description must have at least 10 characters")
        if errors:
            return [False, errors]
        else:
            course = Course.objects.create(name = name, description = description)
            return [True, course]
class Course(models.Model):
    name = models.CharField(max_length = 100)
    description = models.CharField(max_length = 1000)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    objects = CourseManager()
