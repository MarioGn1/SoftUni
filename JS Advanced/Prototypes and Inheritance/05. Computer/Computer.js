function solve() {
    class Product {
        constructor(manufacturer) {
            if (new.target === Product) {
                throw new Error('Canot instantiate directly.')
            }
            this.manufacturer = manufacturer;
        }
    }
    class Keyboard extends Product {
        constructor(manufacturer, responseTime) {
            super(manufacturer);
            this.responseTime = responseTime;
        }
    }
    class Monitor extends Product {
        constructor(manufacturer, width, height) {
            super(manufacturer);
            this.width = width;
            this.height = height;
        }
    }
    class Battery extends Product {
        constructor(manufacturer, expectedLife) {
            super(manufacturer);
            this.expectedLife = expectedLife;
        }
    }
    class Computer extends Product {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
            if (new.target === Computer) {
                throw new Error('Canot instantiate directly.')
            }
            super(manufacturer);
            this.processorSpeed = processorSpeed;
            this.ram = ram;
            this.hardDiskSpace = hardDiskSpace;
        }
    }
    class Laptop extends Computer {
        #battery = null;
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        get battery() { return this.#battery }
        set battery(value) {
            if (!(value instanceof Battery)) {
                throw new TypeError('The given argument is not the correct type!')
            }
            this.#battery = value;
        }
    }
    class Desktop extends Computer {
        #keyboard = null;
        #monitor = null;
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.keyboard = keyboard;
            this.monitor = monitor;

        }
        get keyboard() { return this.#keyboard }
        set keyboard(value) {
            if (!(value instanceof Keyboard)) {
                throw new TypeError('The given argument is not the correct type!')
            }
            this.#keyboard = value;
        }
        get monitor() { return this.#monitor }
        set monitor(value) {
            if (!(value instanceof Monitor)) {
                throw new TypeError('The given argument is not the correct type!')
            }
            this.#monitor = value;
        }
    }    

    return { Product, Keyboard, Monitor, Battery, Computer, Laptop, Desktop }
}

let classes = solve();
let Computer = classes.Computer;
let Laptop = classes.Laptop;
let Desktop = classes.Desktop;
let Monitor = classes.Monitor;
let Battery = classes.Battery;
let Keyboard = classes.Keyboard;

let keyboard = new Keyboard('Logitech', 70);
let monitor = new Monitor('Benq', 28, 18);
let desktop = new Desktop("JAR Computers", 3.3, 8, 1, keyboard, monitor);
console.log(desktop.manufacturer)
console.log(desktop.processorSpeed)
console.log(desktop.ram)
console.log(desktop.hardDiskSpace)
console.log(desktop.keyboard)
console.log(desktop.monitor)

// expect(desktop.manufacturer).to.equal("JAR Computers",'Expected manufacturer did not match.');
// expect(desktop.processorSpeed).to.be.closeTo(3.3,0.01,'Expected processor speed did not match.');
// expect(desktop.ram).to.equal(8,'Expected RAM did not match.');
// expect(desktop.hardDiskSpace).to.equal(1,'Expected hard disk space did not match.');
// expect(desktop.keyboard).to.equal(keyboard,'Expected keyboard did not match.');
// expect(desktop.monitor).to.equal(monitor,'Expected monitor did not match.');