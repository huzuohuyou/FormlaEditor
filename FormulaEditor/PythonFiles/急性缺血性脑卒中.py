# -*- coding:UTF-8 -*-
import sys
import clr
import System
sys.path.append(System.AppDomain.CurrentDomain.BaseDirectory+"\PythonFiles\DLLs")
clr.AddReferenceToFile("Newtonsoft.Json.dll")
from Newtonsoft.Json import *
def method_factory(method_name,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
	func = getattr(Foo(),method_name)
	return func(p1,p2,p3,p4,p5,p6,p7,p8)
class Foo:
    def demo(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		return '测试方法'
    def 术前完成直肠指诊的比率(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
		'''
		分子：分母中，术前完成直肠指诊的病例数； 分母：入组患者； 计算方法：（分子/分母）×100%
		p1:术前完成直肠指诊检查1
		p2 术前完成直肠指诊检查2
		p3:None
		p4:None
		p5:None
		p6:None
		p7:None
		p8:None
		'''
		return 1

    def patient(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
        return str(p1.__dict__)
    def user_net(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):
        from System.Guid import NewGuid, ToByteArray
        g = NewGuid()
        return g
    def json_demo(self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None):      
        json_text="[{'a':'aaa','b':'bbb','c':'ccc'},{'a':'aa','b':'bb','c':'cc'}]"
        json_obj=JsonConvert.DeserializeObject(json_text)
        return json_obj
        