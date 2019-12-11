# SB Admin 2

SB Admin 2 is an open source template project created by David Miller for Bootstrap 4+.

## Installation

Use the package manager to install this package or use the console.

```bash
Install-Package SBAdmin2.Template 
```

## Change Tracking

The following files will be replaced by this package:

```bash
~/Views/Shared/_Layout.cshtml
~/Views/Content/Site.css
```

The following files will be added:
```bash
~/Views/Shared/_AdminLayout.cshtml
~/Content/sb-admin.css
~/Content/sb-admin.min.css
~/Scritps/vendor
~/Scripts/sb-admin.js
~/Scripts/sb-admin.min.js
```

## Usage

This package should work out of the box, however you must make some additional changes to your project.

To utilize the Admin Dashboard using _AdminLayout.cshtml you must perform this change in _ViewStart.cshtml file located in the Views folder.

```python
Layout = "~/Views/Shared/_AdminLayout.cshtml";
```

OPTIONAL: SB Admin CSS and JS files can be added to BundleConfig.cs

```python
bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/sb-admin.css",
                      "~/Content/site.css"));
```

```python
bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/sb-admin.css",
                      "~/Content/site.css"));
```
```python
bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/sb-admin.js",
                      "~/Scripts/respond.js"));
```
If you add these lines to the BundleConfig you must remove them from the _AdminLayout.cshtml

NOTE: All Bootstrap 4 navigation links must include the css class "nav-link"

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.


## License
[MIT](https://choosealicense.com/licenses/mit/)