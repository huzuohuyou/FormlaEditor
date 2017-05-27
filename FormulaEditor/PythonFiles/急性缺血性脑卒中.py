def method_factory(method_name,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
	func = getattr(Foo(),method_name)
	return func(p1,p2,p3,p4,p5,p6,p7,p8)
class Foo:
	def test(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		return "测试方法"

	def hello_word(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		return "hello world"

	def plus(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		return p1+p2

	def sub(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		return p1-p2

	def multi(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		return p1*p2

	def div(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		return p1/p2

	def test(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		if(p5>0):
			if(p3>p4):
				return -1
			else:
				return -2
		else:
			return -3