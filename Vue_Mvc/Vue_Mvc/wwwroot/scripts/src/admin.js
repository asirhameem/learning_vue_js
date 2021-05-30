import Vue from 'vue';
import router from './router/adminRoute';
import Admin from './Admin.vue';
new Vue({
    el: '#admin',
    router: router,
    render: h => h(Admin)
})