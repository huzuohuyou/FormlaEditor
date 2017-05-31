# -*- coding:UTF-8 -*-
def method_factory(method_name,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
	func = getattr(Foo(),method_name)
	return func(p1,p2,p3,p4,p5,p6,p7,p8)

class Hotel(object):
    """docstring for Hotel"""
    def __class__():
        return 1
    def __init__(self, room, cf=1.0, br=15):
    
        self.room = room
        self.cf = cf
        self.br = br
class Foo:
    
    #name='wu'#
    def demo(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
        #p=Foo()
        hotel=Hotel('10')
        return str(hotel.__dict__)

	
	def swfzjzb(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		'''
		p1:医嘱开立时间
		p2:检验申请时间
		p3:检查申请时间
		p4:None
		p5:None
		p6:None
		p7:None
		p8:None
		'''
		return 12
	
	
			
	def d3(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		'''
		p1:1
		p2:2
		p3:None
		p4:None
		p5:None
		p6:None
		p7:None
		p8:None
		'''
		return 1
	def fun1(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		'''
		到院24小时内完成实验室检验的比率
		p1:血糖检验时间
		p2:血常规检验时间
		p3:肝功检验时间
		p4:肾功检验时间
		p5:入组患者
		p6:入院时间
		p7:None
		p8:None
		'''
		num = 7
		if int(p1)-int(p6)>24:
			num=num+1
		if int(p2)-int(p6)>24:
			num=num+1
		if int(p3)-int(p6)>24:
			num=num+1
		if int(p4)-int(p6)>24:
			num=num+1
		return num/float(p5)

f = Foo()
print(f.demo())