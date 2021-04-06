let obj = new Vue({
    el: '#first',
    data: {
        name: "Asir Hameem"
    },
    methods: {
        GetName() {
            return this.name;
        }
    },
    template: '<div> <h2>My name is : {{ GetName() }}</h2></div>'
})