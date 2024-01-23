from abc import ABC, abstractmethod

class Log:
    def write_log(self, msg):
        print(msg)

class Car:
    def __init__(self, engine, transmission):
        self.engine = engine
        self.transmission = transmission
        
    def get_details(self):
        return f"Engine: {self.engine.retrieve_name()}, Transmission: {self.transmission.obtain_name()}"

class ITransmission(ABC):
    @abstractmethod
    def set_transmission(self, name):
        pass
    
    @abstractmethod
    def obtain_name(self):
        pass

class Transmission(ITransmission):
    def set_transmission(self, name):
        self.name = name
    
    def obtain_name(self):
        return self.name

class IEngine(ABC):
    @abstractmethod
    def set_name(self, name):
        pass
    
    @abstractmethod
    def retrieve_name(self):
        pass

class Engine(IEngine):
    def __init__(self, fuel_pump, start_up_motor):
        self.fuel_pump = fuel_pump
        self.start_up_motor = start_up_motor
        
    def set_name(self, name):
        self.name = name
        
    def retrieve_name(self):
        return self.name

class IFuelPump(ABC):
    @abstractmethod
    def set_name(self, name):
        pass
    
    @abstractmethod
    def retrieve_name(self):
        pass

class FuelPump(IFuelPump):
    def set_name(self, name):
        self.name = name
    
    def retrieve_name(self):
        return self.name

class IStartUpMotor(ABC):
    @abstractmethod
    def set_name(self, name):
        pass
    
    @abstractmethod
    def retrieve_name(self):
        pass

class StartUpMotor(IStartUpMotor):
    def set_name(self, name):
        self.name = name
    
    def retrieve_name(self):
        return self.name

def main():
    log = Log()
    start_up_motor = StartUpMotor()
    start_up_motor.set_name("SMotor")
    fuel_pump = FuelPump()
    fuel_pump.set_name("FuelPumpA")
    engine = Engine(start_up_motor, fuel_pump)
    engine.set_name("EngineA")
    transmission = Transmission()
    transmission.set_transmission("T")
    car = Car(engine, transmission)
    log.write_log(car.get_details())

main()
