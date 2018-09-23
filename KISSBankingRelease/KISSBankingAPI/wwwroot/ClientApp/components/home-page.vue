<template>
  <div class="page">
    <div class="header">
      <div>
        <h1>Welcome to KISS Banking</h1>
        <p>Keep It Simple Stupid Banking</p>
        <p>Welcome to KISS banking, worlds simplest banking, time limited accounts and no encryption. Banking done right.</p>
      </div>
    </div>

    <div class="form">
      <p class="bad-input">{{ this.message }}</p>
      <b-form @submit="onSubmit">
        <b-form-group id="usernameLabel"
                      label="Username"
                      label-for="username">
          <b-form-input id="username"
                        v-model="user.mUsername"
                        required
                        placeholder="Username"></b-form-input>
        </b-form-group>

        <b-form-group id="passwordLabel"
                      label="Password"
                      label-for="password">
          <b-form-input id="password"
                        v-model="user.mPassword"
                        type="password"
                        required
                        placeholder="Password"></b-form-input>
        </b-form-group>
        <b-button type="submit" variant="primary">Login</b-button>
        <b-button v-on:click="signup">Sign up</b-button>
      </b-form>
    </div>


  </div>
</template>
<script>
  import { routes } from '../router/routes'
  import axios from 'axios'

  export default {
    data() {
      return {
        routes,
        collapsed: true,
        user: {
          mUsername: '',
          mPassword: ''
        },
        message: ''
      }
    },
    methods: {
      // Logins in user uging form data
      onSubmit(evt) {
        evt.preventDefault();
        axios.post('api/User/Login', {
          mUsername: this.user.mUsername,
          mPassword: this.user.mPassword
        }).then(response => {
          this.$session.set('user', response.data);
          this.$session.set('username', this.user.mUsername);
          this.$router.push('/account');
        }, error => {
          this.message = "Invalid login details";
          console.log(error)
        });
      },
      // Routes to new user sign up page
      signup: function () {
        this.$router.push('/newuser');
      }
    }
  }
</script>
<style>
</style>
