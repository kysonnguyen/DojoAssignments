from flask import Flask, render_template, request, redirect, session, flash
from mysqlconnection import MySQLConnector
from flask_bcrypt import Bcrypt
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')

app = Flask(__name__)
app.secret_key = 'mysecretkey'

bcrypt = Bcrypt(app)
mysql = MySQLConnector(app, 'the_wall')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/create', methods=['POST'])
def create():
    email_chk_query = "SELECT email FROM users WHERE email = :email"
    email_chk_data = {'email': request.form['email'],}
    email_chk = mysql.query_db(email_chk_query,email_chk_data)
    print email_chk
    if len(request.form['email']) <1 or len(request.form['first_name']) < 1 or len(request.form['last_name']) < 1 or len(request.form['password']) < 1 or len(request.form['confirm']) < 1:
        flash("All fields are required and must not be blank", 'reg_error')
    elif not request.form['first_name'].isalpha() or not request.form['last_name'].isalpha():
        flash('Name is required and must not contain any number!', 'reg_error')
    elif len(request.form['first_name']) < 2 or len(request.form['last_name']) < 2:
        flash('First Name and Last Name must have at least 2 characters each.', 'reg_error')
    elif not EMAIL_REGEX.match(request.form['email']):
        flash("Invalid Email Address!", 'reg_error')
    elif len(request.form['password']) < 8:
        flash('Password must must have more than 7 characters!', 'reg_error')
    elif request.form['password'] != request.form['confirm']:
        flash('Password and Password Confirmation do not match!', 'reg_error')
    elif email_chk:
        flash('Email is already registered. Please use a different email.', 'reg_error')
    else:
        reg_query = "INSERT INTO users (first_name,last_name,email,pw_hash,created_at,updated_at) VALUES (:first_name,:last_name,:email,:pw_hash,NOW(),NOW())"
        reg_data = {
        'first_name': request.form['first_name'],
        'last_name': request.form['last_name'],
        'email': request.form['email'],
        'pw_hash': bcrypt.generate_password_hash(request.form['password'],)
        }
        mysql.query_db(reg_query, reg_data)
        flash('Registration Successful!', 'reg_success')
    return redirect('/')
@app.route('/login', methods = ['POST'])
def login():
    login_query = 'SELECT * FROM users WHERE email = :email'
    login_data = {'email': request.form['email']}
    user = mysql.query_db(login_query, login_data)
    if len(request.form['email']) < 1 or len(request.form['password']) < 1:
        flash('Please put in your email and password', 'login_error')
        return redirect('/')
    elif bcrypt.check_password_hash(user[0]['pw_hash'], request.form['password']):
        session['id'] = user[0]['id']
    else:
        flash('Email or Password is incorrect!', 'login_error')
    return redirect('/wall')
@app.route('/wall', methods = ['POST', 'GET'])
def wall():
    if 'id' in session:
        user_query = "SELECT * FROM users WHERE id=:id"
        user_id = {
            'id': session['id']
        }
        user = mysql.query_db(user_query, user_id)
        messages_query = "SELECT messages.id, messages.user_id, concat(users.first_name, ' ', users.last_name) as name, DATE_FORMAT(messages.created_at, '%M %e, %Y') as created_at, messages.message FROM messages JOIN users on messages.user_id = users.id ORDER BY messages.created_at DESC"
        messages = mysql.query_db(messages_query)
        comments_query = "SELECT comments.message_id, concat(users.first_name, ' ', users.last_name) as name, DATE_FORMAT(comments.created_at, '%M %e, %Y') as created_at, comments.comment FROM comments JOIN users on comments.user_id = users.id ORDER BY comments.created_at ASC"
        comments = mysql.query_db(comments_query)
        return render_template('wall.html', user = user[0]['first_name'], messages = messages, comments = comments)
    else:
        return redirect('/')
@app.route('/post_message', methods = ['POST'])
def post_message():
    if len(request.form['message']) < 1:
        flash('message cannot be empty!', 'message_error')
    else:
        post_message_query = 'INSERT INTO messages(user_id, message, created_at, updated_at) VALUES (:user_id, :message, NOW(), NOW())'
        post_message_data = {
            'user_id': session['id'],
            'message': request.form['message']
        }
        mysql.query_db(post_message_query, post_message_data)
    return redirect('/wall')
@app.route('/post_comment', methods = ['POST'])
def post_comment():
    if len(request.form['comment']) < 1:
        flash('comment cannot be empty!', 'comment_error')
    else:
        post_comment_query = 'INSERT INTO comments (user_id, message_id, comment, created_at, updated_at) VALUES (:user_id, :message_id, :comment, NOW(), NOW())'
        post_comment_data = {
            'user_id': session['id'],
            'message_id': request.form['message_id'],
            'comment': request.form['comment']
        }
        mysql.query_db(post_comment_query, post_comment_data)
    return redirect('/wall')

@app.route('/logout')
def logout():
    session.clear()
    return redirect ('/')
app.run(debug=True)
