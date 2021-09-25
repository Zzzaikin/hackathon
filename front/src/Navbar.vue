<template>
  <v-app-bar flat class="header" height="64" max-height="64">
    <div style="width: 370px"></div>
    <v-spacer></v-spacer>
    <v-tabs v-model="tab">
      <v-tab v-for="tab in tabs" :key="tab.name" :disabled="tab.disabled">{{
        tab.name
      }}</v-tab>
    </v-tabs>
    <span>Аноним</span>

    <v-btn icon>
      <v-avatar>
        <v-icon large> mdi-account-circle </v-icon>
      </v-avatar>
    </v-btn>
    <div style="width: 380px"></div>
  </v-app-bar>
</template>

<script>
export default {
  data: () => ({
    tab: null,
    tabs: [
      { name: "Главная", path: "/", id: 1, disabled: false },
      { name: "Аналитика", path: "/analytics", id: 2, disabled: false },
      {
        name: "Расширенный анализ",
        path: "/employees",
        id: 3,
        disabled: true,
      },
    ],
  }),
  watch: {
    tab(val) {
      this.$router.push(this.tabs[val].path);
    },
    $route(val) {
      if (val.path === "/analytics") {
        this.tab = 1;
      }
      if (val.path === "/") {
        this.tab = 0;
      }
    },
  },
};
</script>
<style scoped>
.sheader {
  height: 64px;
}
</style>
