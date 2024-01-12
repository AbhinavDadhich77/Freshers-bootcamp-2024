from abc import ABC, abstractmethod

class DocumentPart(ABC):
    _name = ''
    _position = ''
    
    @abstractmethod
    def paint(self):
        pass
    
    @abstractmethod
    def convert(self, converter_class):
        pass
 
    @abstractmethod
    def save(self):
        pass
    
class Header(DocumentPart):
    def __init__(self, title="DefaultTitle"):
        self.title = title
    
    def paint(self):
        print("Painting Header titled", self.title)
 
    def save(self):
        print("Saving Header")
        
    def convert(self, converter_class):
        converter_class.convertHeader(self)
 
class Footer(DocumentPart):
    def __init__(self, text="DefaultText"):
        self.text = text
    
    def paint(self):
        print("Painting Footer having text", self.text)
 
    def save(self):
        print("Saving Footer")
        
    def convert(self, converter_class):
        converter_class.convertFooter(self)
 
class Hyperlink(DocumentPart):
    def __init__(self, url="defaultURL.com", text="defaultText"):
        self.url = url
        self.text = text
    
    def paint(self):
        print("Painting Hyperlink having url {} and text {}".format(self.url, self.text))
 
    def save(self):
        print("Saving Hyperlink")
        
    def convert(self, converter_class):
        converter_class.convertHyperLink(self)
 
class Paragraph(DocumentPart):
    def __init__(self, content="defaultContent"):
        self.content = content
        
    def paint(self):
        print("Painting Paragraph having content", self.content)
 
    def save(self):
        print("Saving Paragraph")
        
    def convert(self, converter_class):
        converter_class.convertPara(self)

class ConverterInterface(ABC):
    
    @abstractmethod
    def convertHeader(self, header: Header):
        pass
    
    @abstractmethod
    def convertFooter(self, footer: Footer):
        pass
    
    @abstractmethod
    def convertHyperLink(self, hyperlink: Hyperlink):
        pass
    
    @abstractmethod
    def convertPara(self, paragraph: Paragraph):
        pass
    
class HTMLConverter(ConverterInterface):
    def convertHeader(self, header: Header):
        print("<h1>"+header.title+"</h1>")
        
    def convertFooter(self, footer: Footer):
        print("<h2>"+footer.text+"</h2>")
    
    def convertHyperLink(self, hyperlink: Hyperlink):
        print("<a href = {}>{}</a>".format(hyperlink.url, hyperlink.text))
    
    def convertPara(self, paragraph: Paragraph):
        print("<p>{}</p>".format(paragraph.content))
    
class WordDocument:
    def __init__(self, document_parts=[]):
        self.document_parts = document_parts
        
    def addDocumentPart(self, document_part):
        self.document_parts.append(document_part)
 
    def openDocument(self):
        for part in self.document_parts:
            part.paint()
 
    def saveDocument(self):
        for part in self.document_parts:
            part.save()
            
    def transform(self, converter_object):
        for doc_part in self.document_parts:
            doc_part.convert(converter_object)
            
def main():
    header_obj = Header("Title1")
    hyperlink_obj = Hyperlink("google.co.in", "search")
    footer_obj = Footer()
    paragraph_obj = Paragraph()
    
    document_part_list = [header_obj, footer_obj, hyperlink_obj, paragraph_obj] 
    
    word_doc = WordDocument(document_part_list)
    
    html_converter_obj = HTMLConverter()
     
    word_doc.openDocument()
    print()
    word_doc.saveDocument()
    print()
    print("Converting to HTML")
    print("*"*25)
    
    word_doc.transform(html_converter_obj)
    
main()
