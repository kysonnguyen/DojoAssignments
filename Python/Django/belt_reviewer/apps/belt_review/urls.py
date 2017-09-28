from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^create$', views.register),
    url(r'^login$', views.login),
    url(r'^logout$', views.logout),
    url(r'^books$', views.books),
    url(r'^books/add$', views.add_page),
    url(r'^post$', views.add),
    url(r'^post_review$', views.add_review),
    url(r'^books/(?P<id>\d+)$', views.book),
    url(r'^users/(?P<id>\d+)$', views.user),
    url(r'^delete_review/(?P<id>\d+)$', views.delete_review),
]
