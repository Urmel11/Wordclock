from neopixel import *
import soaplib
import os
from subprocess import call
from soaplib.core.service import rpc, DefinitionBase
from soaplib.core.service import soap
from soaplib.core.model.primitive import String, Integer, Boolean
from soaplib.core.server import wsgi
from soaplib.core.model.clazz import Array

class neopixelWebservice(DefinitionBase):
	@soap(Integer, Integer, Integer, Integer, Boolean, Integer)
	def initialize(self, ledCount, ledPin, ledFrequence, ledDMA, ledInvert, ledBrightness):
		global wrapper
		wrapper = Adafruit_NeoPixel(ledCount, ledPin, ledFrequence, ledDMA, ledInvert, ledBrightness)
		wrapper.begin()

	@soap()
	def dispose(self):
		wrapper.__del__()
	
	@soap()
	def show(self):
		wrapper.show()

	@soap(Integer, Integer, Integer, Integer)
	def setPixelColor(self, ledID, red, green, blue):
		wrapper.setPixelColorRGB(ledID, red, green, blue)

	@soap(_returns=Integer)
	def getNumberOfLEDs(self):
		return wrapper.numPixels()

	@soap(Integer, _returns=Integer)
	def getPixelColor(self, ledID):
		return wrapper.getPixelColor(ledID)
	
	@soap(String,  Integer, Integer, Integer)
	def setPixelColors(self, ids, red, green, blue):
		for pixel in ids.split(','):
			wrapper.setPixelColorRGB(int(pixel), red, green, blue)

	@soap(String)
	def setPixelAndRender(self, renderString):
		for colors in renderString.split('-'):
			pixelPerColor = colors.split(':')
			if len(pixelPerColor) == 4:  
				self.setPixelColors(pixelPerColor[3], int(pixelPerColor[0]), int(pixelPerColor[1]), int(pixelPerColor[2]))
		self.show()

	@soap(Integer)
	def setBrightness(self, brightness):
		wrapper.setBrightness(brightness)
	
	@soap(String, _returns=String)
	def testService(self, message):
		return message[::-1]

	@soap()
	def shutdown(self):
		self.dispose()
		call(["kill", str(os.getpid())])

if __name__=='__main__':
	try:
		from wsgiref.simple_server import make_server
		soap_application = soaplib.core.Application([neopixelWebservice], 'tns')
		wsgi_application = wsgi.Application(soap_application)
		server = make_server('192.168.2.35', 7791, wsgi_application)
		print "Start neopixelWebservice"
		server.serve_forever()
	except KeyboardInterrupt:
        self.dispose()
print "Server beendet!"

