# -*- coding: utf-8 -*-
# Generated by Django 1.11.1 on 2017-06-04 02:05
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('belt_review', '0004_auto_20170603_1823'),
    ]

    operations = [
        migrations.AlterField(
            model_name='author',
            name='book',
            field=models.ManyToManyField(related_name='authors', to='belt_review.Book'),
        ),
    ]
