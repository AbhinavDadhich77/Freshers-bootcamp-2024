from abc import ABC, abstractmethod
import time

class IObserver(ABC):
    @abstractmethod
    def update(self, state):
        pass

class ConcreteObserverA(IObserver):
    def update(self, state):
        # implementation
        pass
    
class Thread:
    def __init__(self):
        self.id = ""
        self.state = ""
        self.priority = 0
        self.culture = ""
        self.array = []
        
    def getState(self):
        return self.state
        
    def getPriority(self):
        return self.priority
        
    def setCulture(self):
        return self.culture
    
    def setState(self,state):
        self.notify(state)
        self.state = state
        
    def setPriority(self,priority):
        self.notify("Priority")
        self.priority = priority
        
    def setCulture(self,culture):
        self.notify("Culture")
        self.culture = state
    
    def notify(self,message):
        for observer in self.array:
            observer.update(self.state)
        print(message, "\nchanged!!\n")
    
    def start(self):
        self.setState("running")
        
    def abort(self):
        self.setState("")
    
    def sleep(self,t):
        self.setState("sleeping")
        time.sleep(t / 1000)
        self.setState("running")
        
    def wait(self):
        self.setState("waiting")
        
    def suspend(self):
        self.setState("suspend")
        
    def attach(self,observerName):
        self.array.append(observerName)
        
    def detach(self,observerName):
        self.array.remove(oberverName)

t1 = Thread()
t1.start()
t1.sleep(10)
print(t1.getState())
