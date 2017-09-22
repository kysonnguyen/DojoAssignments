from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^create$', views.register),
    url(r'^post$', views.post),
    url(r'^login$', views.login),
    url(r'^logout$', views.logout),
    url(r'^secrets$', views.secrets),
    url(r'^delete_secret$', views.delete_secret),
    url(r'^like$', views.like),
    url(r'^popular$', views.popular),
]
