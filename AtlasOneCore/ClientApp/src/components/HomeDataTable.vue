<template>
    <div>
        <v-toolbar light flat dense color="#eeeeee">
            <v-toolbar-title id="dataHeader" flat>Account List</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-dialog v-model="dialog" max-width="500px">
                <v-btn ripple small slot="activator" color="#8e8e8e" dark class="mb-2">New Item</v-btn>
                <v-card>
                    <v-card-title>
                        <span class="headline">{{ formTitle }}</span>
                    </v-card-title>

                    <v-card-text>
                        <v-container grid-list-md>
                            <v-layout wrap>
                                <v-flex xs12 sm6 md4>
                                    <v-text-field v-model="editedItem.schedulerId" label="Scheduler Id"></v-text-field>
                                </v-flex>
                                <v-flex xs12 sm6 md4>
                                    <v-text-field v-model="editedItem.startDate" label="Start Date"></v-text-field>
                                </v-flex>
                                <v-flex xs12 sm6 md4>
                                    <v-text-field v-model="editedItem.endDate" label="End Date"></v-text-field>
                                </v-flex>
                                <v-flex xs12 sm6 md4>
                                    <v-text-field v-model="editedItem.schedules" label="Schedules"></v-text-field>
                                </v-flex>
                            </v-layout>
                        </v-container>
                    </v-card-text>

                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="#8e8e8e" dark @click.native="close">Cancel</v-btn>
                        <v-btn color="#8e8e8e" dark @click.native="save">Save</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-toolbar>
        <v-data-table :loading="true"
                      :headers="headers"
                      :items="desserts"
                      hide-actions
                      class="elevation-1">
            <v-progress-linear slot="progress" color="info" indeterminate v-show="isLoading"></v-progress-linear>
            <template slot="items" slot-scope="props">
                <td>{{ props.item.schedulerId }}</td>
                <td class="text-xs-center">{{ props.item.startDate }}</td>
                <td class="text-xs-center">{{ props.item.endDate }}</td>
                <td class="text-xs-center">{{ props.item.schedules }}</td>
                <td class="justify-center layout px-0">
                    <v-icon small
                            class="mr-2"
                            @click="editItem(props.item)">
                        edit
                    </v-icon>
                    <v-icon small
                            @click="deleteItem(props.item)">
                        delete
                    </v-icon>
                </td>
            </template>
            <template slot="no-data">
                <v-btn color="#4b636e" @click="initialize">Reset</v-btn>
            </template>
        </v-data-table>
    </div>
</template>

<script>
    export default {
        data: () => ({
            isLoading: true,
            dialog: false,
            headers: [
                {
                    text: 'Id',
                    align: 'left',
                    sortable: false,
                    value: 'schedulerId'
                },
                { text: 'Start Date', value: 'startDate' },
                { text: 'End Date', value: 'endDate' },
                { text: 'Schedules', value: 'schedules' },
                { text: 'Actions', value: 'name', sortable: false }
            ],
            desserts: [],
            editedIndex: -1,
            editedItem: {
                schedulerId: null,
                startDate: null,
                endDate: null,
                schedules: [],
            },
            defaultItem: {
                schedulerId: null,
                startDate: null,
                endDate: null,
                schedules: [],
            }
        }),

        computed: {
            formTitle() {
                return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
            }
        },

        watch: {
            dialog(val) {
                val || this.close()
            }
        },

        created() {
            this.initialize()
        },

        methods: {
            initialize() {
                this.desserts = [

                ]
            },

            editItem(item) {
                this.editedIndex = this.desserts.indexOf(item)
                this.editedItem = Object.assign({}, item)
                this.dialog = true
            },

            deleteItem(item) {
                const index = this.desserts.indexOf(item)
                confirm('Are you sure you want to delete this item?') && this.desserts.splice(index, 1)
            },

            close() {
                this.dialog = false
                setTimeout(() => {
                    this.editedItem = Object.assign({}, this.defaultItem)
                    this.editedIndex = -1
                }, 300)
            },

            save() {
                if (this.editedIndex > -1) {
                    Object.assign(this.desserts[this.editedIndex], this.editedItem)
                } else {
                    this.desserts.push(this.editedItem)
                }
                this.close()
            },
            getDbData: function () {
                axios.get("/api/Schedulers")
                    .then(result => {
                        this.desserts = result.data
                        console.log(returnedData)
                    }).catch(error => {
                        console.log(error.response)
                    })
            }
        },
        created() {
            this.getDbData();
            setTimeout(() => {
                this.isLoading = false;
            }, 2000);
        }

    }
</script>

<style>

    #dataHeader {
        font-size: 16px;
    }
</style>