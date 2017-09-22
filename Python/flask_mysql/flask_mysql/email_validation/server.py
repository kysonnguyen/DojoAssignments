from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'email_validation')
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')
app.secret_key = "ThisIsSecret!"
@app.route('/', methods=['GET'])
def index():
    query = "SELECT * FROM emails"
    emails = mysql.query_db(query)
    return render_template("index.html", all_emails = emails)
@app.route('/process', methods=['POST'])
def create():
    if len(request.form['email']) < 1:
        flash("Email cannot be blank!")
    elif not EMAIL_REGEX.match(request.form['email']):
        flash("Invalid Email Address!")
    else:
        flash("Success!")
        query = "INSERT INTO emails (email, created_at) VALUES (:email, NOW())"
        data = {
            'email': request.form['email']
        }
        mysql.query_db(query, data)
    return redirect('/')
app.run(debug=True)
