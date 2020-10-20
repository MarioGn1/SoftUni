function createMixins() {

    function computerQualityMixin(classToExtend) {
        classToExtend.prototype.getQuality = function () {
            return (this.processorSpeed + this.ram + this.hardDiskSpace) / 3;
        }
        classToExtend.prototype.isFast = function () {
            return this.processorSpeed > (this.ram / 4) ? true : false;
        }
        classToExtend.prototype.isRoomy = function(){
            return this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed) ? true : false;
        }
    }
    function styleMixin(classToExtend) {
        classToExtend.prototype.isFullSet = function() {
            if (this.manufacturer === this.keyboard.manufacturer && this.manufacturer ===this.monitor.manufacturer) {
                return true;
            }
            return false;
        }
        classToExtend.prototype.isClassy = function(){
            if (this.battery.expectedLife >= 3 && (this.color === 'Silver' || this.color === 'Black') && this.weight < 3) {
                return true;
            }
            return false;
        }
    }
    return {computerQualityMixin, styleMixin}
}