def method_factory(method_name,p1=None,p2=None,p3=None,p4=None,p5=None):
	if(method_name=="plus"):
		return plus(p1,p2)
	elif(method_name=="sub"):
		return sub(p1,p2)
	elif(method_name=="multi"):
		return multi(p1,p2)
	elif(method_name=="div"):
		return div(p1,p2)
	elif(method_name=="test"):
		return test(p1,p2,p3,p4,p5)
	else:
		return "方法"+method_name+"没有定义!"

def hello_word():
	return "hello world"

def plus(p1,p2):
	return p1+p2

def sub(p1,p2):
	return p1-p2

def multi(p1,p2):
	return p1*p2

def div(p1,p2):
	return p1/p2

def test(p1,p2,p3,p4,p5):
	if(p5>0):
		if(p3>p4):
			return -1
		else:
			return -2
	else:
		return -3

