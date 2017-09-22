from django.conf.urls import url
from . import views

urlpatterns=[
    url(r'^$', views.index),
    url(r'^create$', views.create),
    url(r'^delete/(?P<id>\d+)', views.delete),
    url(r'^delete_confirm/(?P<id>\d+)', views.delete_confirm)
]
