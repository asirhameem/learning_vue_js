let divOne = new Vue({
    el: '#first',
    data: {
        name: "Asir Hameem",
        you: "Hey, Who are you ?"
    },
    methods: {
        GetName() {
            return this.name;
        }
    },
    template: '<div> <h2>My name is : {{ GetName() }}</h2></div>'
});

let divTwo = new Vue({
    el: '#second',
    data: {
        address: "Rajapukur Lane, Chittagong",
        phone: "015214008295",
        university: "AIUB",
        facebook: "https://www.facebook.com/asirhameem/",
        twitter: "https://www.twitter.com/asirhameem/"

    },
    methods: {
        UpdatePhone(number) {
            this.phone = number;
            return this.phone;
        },
        GetAddress() {
            return this.address;
        }
    }
});

let box = new Vue({

    el: '#box',
    data: {
        position: {
            x: 0,
            y: 0
        }
    },
    methods: {
        MouseOver(event) {
            this.position.x = event.offsetX;
            this.position.y = event.offsetY;
            console.log(event);
        },
        Click(event) {
            this.position.x = event.offsetX;
            this.position.y = event.offsetY;
        }
    }
});