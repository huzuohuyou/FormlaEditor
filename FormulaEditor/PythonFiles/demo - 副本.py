﻿def hello_word():
	return "hello world"


def plus(p1,p2):
	return p1+p2

def sub(p1,p2):
	return p1-p2

def multi(p1,p2):
	return p1*p2

def div(p1,p2):
	return p1/p2

def methon_factory(methon_name,p1=None,p2=None,p3=None,p4=None,p5=None):
	if(methon_name=="plus"):
		return plus(p1,p2)
	elif(methon_name=="sub"):
		return sub(p1,p2)
	elif(methon_name=="multi"):
		return multi(p1,p2)
	elif(methon_name=="div"):
		return div(p1,p2)