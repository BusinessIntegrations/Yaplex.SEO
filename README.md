The **BI/public** branch in this fork of this code is managed by [Business Integrations Ltd](https://github.com/BusinessIntegrations).

A changelog is appended at the end of this file. Further information on our coding standards and approach are detailed [here](https://businessintegrations.github.io/).

***

# Yaplex.SEO
SEO (search engine optimization) module for Orchard CMS

More information at product page https://yaplex.com/products/yaplex-seo

***

## Business Integrations Changelog
1. Module rework 2018-04-04
   * Fixed serious bug in SeoOverrideDriver.cs that caused infinite recursion.
   * Updated SEO Driver to only update meta-data when displayType==”Detail”.
   * Added import/export code.
   * Moved Robots controller/menu to use driver/site settings instead.
   * Added caching service.
   * Code tidy
   * Update readme.md
2. Introduced Controller 2018-05-04
   * Amended module to use admin menu / controller instead of driver / site settings menu.
   * Added permission in order to view menu / manage settings.
   * Added basic caching of business data. 
   * Rationalised string constants, updated module version, updated placement info, general code tidy etc.
