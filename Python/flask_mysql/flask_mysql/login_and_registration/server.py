from flask import Flask, render_template, request, redirect, session, flash
from mysqlconnection import MySQLConnector
from flask_bcrypt import Bcrypt
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')

app = Flask(__name__)
app.secret_key = 'mysecretkey'

bcrypt = Bcrypt(app)
mysql = MySQLConnector(app, 'login_and_registration')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/create', methods=['POST'])
def create():
    email_chk_query = "SELECT count(id) FROM users WHERE email = :email"
    email_chk_data = {'email': request.form['email'],}
    email_chk = mysql.query_db(email_chk_query,email_chk_data)
    print email_chk
    if len(request.form['email']) <1 or len(request.form['first_name']) < 1 or len(request.form['last_name']) < 1 or len(request.form['password']) < 1 or len(request.form['confirm']) < 1:
        flash("All fields are required and must not be blank", 'error')
    if not request.form['first_name'].isalpha() or not request.form['last_name'].isalpha():
        flash('Name is required and must not contain any number!', 'error')
    elif len(request.form['first_name']) < 2 or len(request.form['last_name']) < 2:
        flash('First Name and Last Name must have at least 2 characters each.', 'error')
    if not EMAIL_REGEX.match(request.form['email']):
        flash("Invalid Email Address!", 'error')
    if len(request.form['password']) < 8:
        flash('Password must must have more than 7 characters!', 'error')
    elif request.form['password'] != request.form['confirm']:
        flash('Password and Password Confirmation do not match!', 'error')
    if email_chk[0]['count(id)'] > 0:
        flash('Email is already registered. Please use a different email.', 'error')
    else:
        reg_query = "INSERT INTO users (first_name,last_name,email,pw_hash,created_at,updated_at) VALUES (:first_name,:last_name,:email,:pw_hash,NOW(),NOW())"
        reg_data = {
        'first_name': request.form['first_name'],
        'last_name': request.form['last_name'],
        'email': request.form['email'],
        'pw_hash': bcrypt.generate_password_hash(request.form['password'],)
        }
        mysql.query_db(reg_query, reg_data)
        flash('Registration Successful!', 'success')
    return redirect('/')

@app.route('/login', methods = ['POST'])
def login():
    login_query = 'SELECT * FROM users WHERE email = :email'
    login_data = {'email': request.form['email']}
    user = mysql.query_db(login_query, login_data)
    if bcrypt.check_password_hash(user[0]['pw_hash'], request.form['password']):
        session['id'] = user[0]['id']
        return render_template('success.html', user = user[0]['first_name'], login = True)
    else:
        flash('Email or Password is incorrect!', 'error')
        return redirect('/')
app.run(debug=True)
