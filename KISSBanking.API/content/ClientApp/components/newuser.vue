<template>
  <div class="page">
    <div class="header">
      <div>
        <h1>New User</h1>
      </div>
    </div>

    <p>Signup with KISS Banking</p>
    <div class="form">
      <p class="bad-input">{{ this.message }}</p>
      <b-form @submit="onSubmit">
        <b-form-group id="usernameLabel"
                      label="Username"
                      label-for="username">
          <b-form-input if="username"
                        v-model="user.mUsername"
                        required
                        placeholder="Username">

          </b-form-input>
        </b-form-group>
        <b-form-group id="passwordLabel"
                      label="Password"
                      label-for="password">
          <b-form-input id="password"
                        v-model="user.mPassword"
                        type="password"
                        required
                        placeholder="Password">
          </b-form-input>
        </b-form-group>
        <b-form-group id="vertifyPasswordLabel"
                      label="Verify Password"
                      label-for="vertifyPassword">
          <b-form-input id="vertifyPassword"
                        v-model="user.mPasswordVerify"
                        type="password"
                        required
                        placeholder="Verify Password">
          </b-form-input>
        </b-form-group>
        <b-button type="submit" variant="primary">Creat Account</b-button>
        <b-button v-on:click="back">Back</b-button>
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
          mPassword: '',
          mPasswordVerify: ''
        },
        message: ''
      }
    },
    methods: {
      // Creates a new user from form data
      onSubmit(evt) {
        evt.preventDefault();
        if (this.user.mPassword !== this.user.mPasswordVerify) {
          this.message = 'Passwords do not match'
        } else {
          axios.post('api/User/CreateUser', {
            mUsername: this.user.mUsername,
            mPassword: this.user.mPassword
          }).then(response => {
            this.message = response.data;
            this.$router.push('/');
          }, error => {
            console.log(error.response)
            this.message = error.response.data;
          });
        }
      },
      // Routes user back to main page
      back() {
        this.$router.push('/');
      }
    }
  }
</script>
<style scoped>

  .slide-enter-active, .slide-leave-active {
    transition: max-height .35s
  }

  .slide-enter, .slide-leave-to {
    max-height: 0px;
  }

  .slide-enter-to, .slide-leave {
    max-height: 20em;
  }
</style>
