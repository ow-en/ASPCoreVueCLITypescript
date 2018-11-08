<template>
    <v-footer color="#fafafa"
              dense
              light
              fixed
              height="auto">
        <v-card class="flex"
                color="#eeeeee"
                flat
                tile>
            <v-layout justify-space-around>
                <v-icon medium color="green darken-2">business</v-icon>
                        
                <v-icon medium color="blue darken-2">chat</v-icon>
                        
                <v-icon medium color="purple darken-2">dialpad</v-icon>
                        
                <v-icon medium color="teal darken-2">email</v-icon>
                        
                <v-icon medium color="blue-grey darken-2">call_split</v-icon>
                        
                <v-icon medium color="orange darken-2">present_to_all</v-icon>
            </v-layout>

            <v-card-actions color="#093c71">
                &copy;2018 — <strong>Atlas General Insurance Services</strong>
            </v-card-actions>
        </v-card>
    </v-footer>
</template>

<script>
  export default {
    data: () => ({
      icons: [
        'fab fa-facebook',
        'fab fa-twitter',
        'fab fa-google-plus',
        'fab fa-linkedin',
        'fab fa-instagram'
      ]
    })
  }
</script>

<style>
    .v-card__actions {
        background: #093c71 !important;
        color: white !important;
    }

    .v-layout {
        
    }
</style>