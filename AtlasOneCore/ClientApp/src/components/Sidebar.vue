<template>
    <v-layout wrap
              style="height: 200px;">
        <v-container>
            <v-layout justify-center>
                <v-btn color="#ff7043"
                       dark
                       @click.stop="drawer = !drawer">
                    My Profile
                </v-btn>
            </v-layout>
        </v-container>

        <v-navigation-drawer v-model="drawer"
                             absolute
                             temporary>
            <v-list dense>
                <v-list-tile @click.stop="left = !left">
                    <v-list-tile-action>
                        <v-icon>exit_to_app</v-icon>
                    </v-list-tile-action>
                    <v-list-tile-content>
                        <v-list-tile-title>Open Temporary Drawer</v-list-tile-title>
                    </v-list-tile-content>
                </v-list-tile>
            </v-list>
            <v-list class="pa-1">
                <v-list-tile avatar>
                    <v-list-tile-avatar>
                        <img src="https://randomuser.me/api/portraits/men/85.jpg">
                    </v-list-tile-avatar>

                    <v-list-tile-content>
                        <v-list-tile-title>John Leider</v-list-tile-title>
                    </v-list-tile-content>
                </v-list-tile>
            </v-list>

            <v-list class="pt-0" dense>
                <v-divider></v-divider>

                <v-list-tile v-for="item in items"
                             :key="item.title"
                             ripple @click="">
                    <v-list-tile-action>
                        <v-icon>{{ item.icon }}</v-icon>
                    </v-list-tile-action>

                    <v-list-tile-content>
                        <v-list-tile-title>{{ item.title }}</v-list-tile-title>
                    </v-list-tile-content>
                </v-list-tile>
            </v-list>
        </v-navigation-drawer>
        <v-navigation-drawer v-model="left"
                             left
                             temporary
                             fixed></v-navigation-drawer>
    </v-layout>
</template>

<script>
  export default {
    data () {
        return {
        left: false,
        drawer: null,
        items: [
          { title: 'Home', icon: 'dashboard' },
          { title: 'About', icon: 'question_answer' }
        ]
      }
    }
  }
</script>