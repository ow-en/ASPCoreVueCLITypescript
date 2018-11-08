<template>
	<v-app id="inspire">
			<v-navigation-drawer v-model="drawerRight"
								 fixed
								 right
								 clipped
								 app>
				<v-list dense>
					<v-list-tile @click.stop="right = !right">
						<v-list-tile-action>
							<v-icon>exit_to_app</v-icon>
						</v-list-tile-action>
						<v-list-tile-content>
							<v-list-tile-title>Open Temporary Drawer</v-list-tile-title>
						</v-list-tile-content>
					</v-list-tile>
				</v-list>
			</v-navigation-drawer>
			<v-toolbar color="#cfd8dc"
					   light
					   fixed
					   app
					   scroll-off-screen
					   clipped-right>
				<v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
				<img class="atlasLogo" src="@/assets/AtlasLogo.svg"
					 alt="AtlasOne" />

				<v-spacer></v-spacer>
				<v-toolbar-side-icon @click.stop="drawerRight = !drawerRight"></v-toolbar-side-icon>
			</v-toolbar>
			<v-card flat id="searchCard">
				<v-toolbar color="#fafafa"
						   light
						   right
						   dense
						   app
						   floating>
					<v-text-field hide-details
								  prepend-icon="search"
								  single-line></v-text-field>

					<v-btn icon>
						<v-icon>my_location</v-icon>
					</v-btn>

					<v-btn icon>
						<v-icon>more_vert</v-icon>
					</v-btn>
				</v-toolbar>
			</v-card>


			<v-navigation-drawer v-model="drawer"
								 fixed
								 app
								 persistent
								 stateless
								 value="true">
				<v-list>
					<v-list-tile>
						<v-list-tile-action>
							<v-icon>home</v-icon>
						</v-list-tile-action>
						<v-list-tile-title>Home</v-list-tile-title>
					</v-list-tile>

					<v-list-group prepend-icon="account_circle"
								  value="true">
						<v-list-tile slot="activator">
							<v-list-tile-title>Users</v-list-tile-title>
						</v-list-tile>

						<v-list-group no-action
									  sub-group
									  value="true">
							<v-list-tile slot="activator">
								<v-list-tile-title>Admin</v-list-tile-title>
							</v-list-tile>

							<v-list-tile v-for="(admin, i) in admins"
										 :key="i"
										 ripple @click="">
								<v-list-tile-title v-text="admin[0]"></v-list-tile-title>
								<v-list-tile-action>
									<v-icon v-text="admin[1]"></v-icon>
								</v-list-tile-action>
							</v-list-tile>
						</v-list-group>

						<v-list-group sub-group
									  no-action>
							<v-list-tile slot="activator">
								<v-list-tile-title>Actions</v-list-tile-title>
							</v-list-tile>

							<v-list-tile v-for="(crud, i) in cruds"
										 :key="i"
										 ripple @click="">
								<v-list-tile-title v-text="crud[0]"></v-list-tile-title>
								<v-list-tile-action>
									<v-icon v-text="crud[1]"></v-icon>
								</v-list-tile-action>
							</v-list-tile>
						</v-list-group>
					</v-list-group>
				</v-list>
				<sidebar></sidebar>
			</v-navigation-drawer>

			<v-content>
				<v-container fluid grid-list-lg>
					<v-layout align-center justify-center row fill-height>
						<v-flex d-flex lg12>
							<home-data-table></home-data-table>
						</v-flex>
					</v-layout>
				</v-container>
			</v-content>
			<floating-action-button></floating-action-button>
			<v-navigation-drawer v-model="right"
								 right
								 temporary
								 fixed></v-navigation-drawer>
			<footer></footer>
	</v-app>
</template>

<script>
	import HomeDataTable from './HomeDataTable'
	import FloatingActionButton from './FloatingActionButton'
    import Sidebar from './Sidebar'
    import Footer from './Footer'



	export default {
		components: {
			HomeDataTable,
			FloatingActionButton,
            Sidebar,
            Footer
		},
		data: () => ({
			items: [
				{ src: require('@/assets/AtlasSymbol.svg') }
			],
			returnedData: [],
			drawer: null,
			drawerRight: null,
			right: false,
			admins: [
				['Management', 'people_outline'],
				['Settings', 'settings']
			],
			cruds: [
				['Create', 'add'],
				['Read', 'insert_drive_file'],
				['Update', 'update'],
				['Delete', 'delete']
			]
		}),
		props: {
			source: String
		},
		methods: {

		}
	}
</script>

<style>
	/*#inspire {
		background: url("../assets/topography.png") !important;
	}*/
	.atlasLogo {
		max-height: 110px;
		margin-bottom: 15px;
		margin-left: 10px;
		margin-top: 15px;
	}

	#searchCard {
		background: #fafafa
	}
</style>