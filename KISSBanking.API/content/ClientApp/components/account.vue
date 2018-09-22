<template>
  <div class="page">
    <div class="header">
      <div>
        <h1>Account</h1>
        <p>Hello {{ this.name }}, wlecome to KISS Banking</p>
      </div>
      <div>
        <b-button v-on:click="logout">Logout</b-button>
      </div>
    </div>

    <div class="form">
      <p class="bad-input">{{ this.message }}</p>
      <b-form @submit="onSubmit" @reset="onReset">
        <b-form-group id="transactionBalanceLabel"
                      label="Transaction Amount"
                      label-for="transactionBalance">
          <b-form-input id="transactionBalance"
                        v-model="Transaction.Amount.mBalance"
                        :state="moneyValidate"
                        placeholder="Enter Amount"
                        required
                        label="Transfer Amount">
          </b-form-input>
        </b-form-group>
        <b-form-group id="transactionTypeLabel"
                      label="Transaction Type"
                      label-for="transactionType">
          <b-form-select id="transactionType"
                         v-model="Transaction.TransactionType"
                         :state="transferTypeValidate"
                         :options="options"
                         class="mb-3"
                         required
                         label="Transfer Type">
          </b-form-select>
        </b-form-group>
        <b-button type="submit" variant="primary">Submit</b-button>
        <b-button type="reset" variant="danger">Reset</b-button>
      </b-form>
    </div>

    <b-container class="transactions">
      <h2 class="current-balance"> Current Balance ${{ this.Account.mcAccountBalance.mBalance }}</h2>
      <b-row>
        <b-col><h3>Transaction</h3></b-col>
        <b-col><h3>Amount</h3></b-col>
      </b-row>
      <b-row v-for="transaction in Account.mcTransactions">
        <b-col v-if="transaction.transactionType === 0">Withdraw</b-col>
        <b-col v-if="transaction.transactionType === 1">Deposit</b-col>
        <b-col>${{ transaction.amount.mBalance }}</b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
  import axios from 'axios'

  export default {
    components: {
    },
    data() {
      return {
        name: '',
        UserId: null,
        message: '',
        Account: {},
        Transaction: {
          Amount: {
            mBalance: null
          },
          TransactionType: null,
          UserId: null
        },
        options: [
          { value: null, text: 'Please select Transaction Type', disabled: true },
          { value: 'WITHDRAW', text: 'Widthdraw' },
          { value: 'DEPOSIT', text: 'Deposit' },
        ]
      }
    },
    computed: {
      // Handles validation for transaction amount
      moneyValidate() {
        var bResult = null
        var Decimal = /^\d+(?:\.\d{0,2})$/
        var Integer = /^\d+(\d{0})$/
        if (this.Transaction.Amount.mBalance) {
          if (Decimal.test(this.Transaction.Amount.mBalance) || Integer.test(this.Transaction.Amount.mBalance)) {
            bResult = null
          } else {
            bResult = false
          }
        }
        return bResult
      },
      transferTypeValidate: {

      }
    },
    methods: {
      // Submits a new transaction using the form data
      onSubmit(evt) {
        evt.preventDefault();
        console.log(this.Transaction.Amount.mBalance)
        axios.post('api/Transaction/CreateTransaction', {
          TransactionType: this.Transaction.TransactionType,
          Amount: this.Transaction.Amount,
          UserId: this.UserId
        }).then(response => {
          this.message = response.data;
        }, error => {
          this.message = "Sorry, you don't have that much to withdraw";
          console.log(error)
        });
        this.getTransaction()
      },
      // Resets the form information
      onReset(evt) {
        evt.preventDefault();
        this.Transaction.Amount.mBalance = ''
        this.Transaction.TransactionType = null
      },
      // Checks session variables for user login
      checkAuth: function () {
        if (!this.$session.exists('user') || !this.$session.exists('username')) {
          this.$router.push('/');
        } else {
          this.name = this.$session.get('username')
          this.UserId = this.$session.get('user')
        }
      },
      // Removes session varaibles for user logout
      logout: function () {
        this.$session.remove('username')
        this.$session.remove('user')
        this.$router.push('/');
      },
      // Gets a list of transactions for the current user
      getTransaction: function () {
        axios.get('api/Transaction/GetAccount/' + this.UserId).then(response => {
          this.Account = response.data
          console.log(response)
          vm.$forceUpdate()
        }, error => {
          console.log(error)
          this.message = 'Cannot get user account'
        });
      }
    },
    // Checks authorization and gets transaction before mounting
    beforeMount() {
      this.checkAuth()
      this.getTransaction()
    },
  }
</script>
<style>
  .transactions {
    padding-top: 40px;
  }

  .row {
    padding: 10px;
  }

  .row:nth-child(odd) {
    background-color: whitesmoke;
  }

  .current-balance {
    padding: 10px;
  }
</style>
