
|       |              |                                                       |           |                      |
| ----- | ------------ | ----------------------------------------------------- | --------- | -------------------- |
| Index | Key          | Description                                           | Data Type | Unit                 |
| 0     | id           | HYG Database ID                                       | int       |                      |
| 1     | hip          | Hipparcos Catalog ID                                  | int       |                      |
| 2     | hd           | Henry Draper Catalog ID                               | int       |                      |
| 3     | hr           | Harvard Revised / Yale Bright Star Catalog ID         | int       |                      |
| 4     | gl           | Gliese Catalog v3 ID                                  | int       |                      |
| 5     | bf           | Bayer / Flamsteed designation                         | string    |                      |
| 6     | proper       | Common Name ie 'Sol'                                  | string    |                      |
| 7     | ra           | Right Ascension                                       | float     | degrees              |
| 8     | dec          | Declination                                           | float     | degrees              |
| 9     | dist         | Distance from earth                                   | float     | parsecs              |
| 10    | pmra         | Proper Motion Right Ascension                         | float     | milliarcseconds/year |
| 11    | pmdec        | Proper Motion Declination                             | float     | milliarcseconds/year |
| 12    | rv           | Radial Velocity                                       | float     | km/sec               |
| 13    | mag          | Apparent visual magnitude                             | float     |                      |
| 14    | absmag       | Absolute visual magnitude from distance of 10 parsecs | float     |                      |
| 15    | spect        | Spectral type                                         | string    |                      |
| 16    | ci           | Color Index                                           | float     |                      |
| 17    | x            | Cartesian X Position - Vernal Equinox                 | float     | parsecs              |
| 18    | y            | Cartesian Y Position - R.A. 6 hours; dec 0 degrees    | float     | parsecs              |
| 19    | z            | Cartesian Z Position - North Celestial Pole           | float     | parsecs              |
| 20    | vx           | Cartesian X Velocity - Vernal Equinox                 | float     | parsecs/year         |
| 21    | vy           | Cartesian Y Velocity - R.A. 6 hours; dec 0 degrees    | float     | parsecs/year         |
| 22    | vz           | Cartesian Z Velocity - North Celestial Pole           | float     | parsecs/year         |
| 23    | rarad        | Right Ascension                                       | float     | radians              |
| 24    | decrad       | Declination                                           | float     | radians              |
| 25    | pmrarad      | Proper Motion Right Ascension                         | float     | radians/year         |
| 26    | pmdecrad     | Proper Motion Declination                             | float     | radians/year         |
| 27    | bayer        | Bayer Designation                                     | string    |                      |
| 28    | flam         | Flamsteed Designation                                 | string    |                      |
| 29    | con          | Standard Constellation Abbreviation                   | string    |                      |
| 30    | comp         | multi-star system Companion Star ID                   | int       |                      |
| 31    | comp_primary | multi-star system Primary Star ID                     | int       |                      |
| 32    | base         | multi-star system Catalog ID                          | int       |                      |
| 33    | lum          | Luminosity                                            | float     | Solar Luminosity     |
| 34    | var          | Variable Star Designation                             | string    |                      |
| 35    | var_min      | Variable Star Minimum Magnitude                       | float     |                      |
| 36    | var_max      | Variable Star Maximum Magnitude                       | float     |                      |

EXAMPLE

| 0   | 1   | 2      | 3   | 4   | 5   | 6      | 7        | 8          | 9        | 10      | 11      | 12    | 13      | 14     | 15           | 16     | 17         | 18       | 19          | 20          | 21          | 22          | 23                      | 24                   | 25                          | 26                 | 27    | 28   | 29  | 30   | 31           | 32   | 33                  | 34  | 35      | 36      |
| --- | --- | ------ | --- | --- | --- | ------ | -------- | ---------- | -------- | ------- | ------- | ----- | ------- | ------ | ------------ | ------ | ---------- | -------- | ----------- | ----------- | ----------- | ----------- | ----------------------- | -------------------- | --------------------------- | ------------------ | ----- | ---- | --- | ---- | ------------ | ---- | ------------------- | --- | ------- | ------- |
| id  | hip | hd     | hr  | gl  | bf  | proper | ra       | dec        | dist     | pmra    | pmdec   | rv    | mag     | absmag | spect        | ci     | x          | y        | z           | vx          | vy          | vz          | rarad                   | decrad               | pmrarad                     | pmdecrad           | bayer | flam | con | comp | comp_primary | base | lum                 | var | var_min | var_max |
| 0   |     |        |     |     |     | Sol    | 0.000000 | 0.000000   | 0.0000   | 0.00    | 0.00    | 0.0   | -26.700 | 4.850  | G2V          | 0.656  | 0.000005   | 0.000000 | 0.000000    | 0.00000000  | 0.00000000  | 0.00000000  | 0                       | 0                    | 0                           | 0                  |       |      |     | 1    | 0            |      | 1                   |     |         |         |
| 1   | 1   | 224700 |     |     |     |        | 0.000060 | 1.089009   | 219.7802 | -5.20   | -1.88   | 0.0   | 9.100   | 2.390  | F5           | 0.482  | 219.740502 | 0.003449 | 4.177065    | 0.00000004  | -0.00000554 | -0.00000200 | 0.000015693409775347223 | 0.01900678824815125  | -0.000000025210311388888885 | -0.000000009114497 |       |      | Psc | 1    | 1            |      | 9.638290236239703   |     |         |         |
| 2   | 2   | 224690 |     |     |     |        | 0.000283 | -19.498840 | 47.9616  | 181.21  | -0.93   | 0.0   | 9.270   | 5.866  | K3V          | 0.999  | 45.210918  | 0.003365 | -16.008996  | -0.00000007 | 0.00004213  | -0.00000020 | 0.00007396114511717882  | -0.34031895245171123 | 0.0000008785308705347223    | -0.000000004508767 |       |      | Cet | 1    | 2            |      | 0.39228346253952057 |     |         |         |
| 3   | 3   | 224699 |     |     |     |        | 0.000335 | 38.859279  | 442.4779 | 5.24    | -2.91   | 0.0   | 6.610   | -1.619 | B9           | -0.019 | 344.552785 | 0.030213 | 277.614965  | 0.00000392  | 0.00001124  | -0.00000486 | 0.00008762628707253473  | 0.6782223625543176   | 0.00000002540423686111111   | -0.000000014108078 |       |      | And | 1    | 3            |      | 386.9011316551087   |     |         |         |
| 4   | 4   | 224707 |     |     |     |        | 0.000569 | -51.893546 | 134.2282 | 62.85   | 0.16    | 0.0   | 8.060   | 2.421  | F0V          | 0.370  | 82.835513  | 0.012476 | -105.619540 | 0.00000008  | 0.00004090  | 0.00000006  | 0.00014895417223450522  | -0.9057132322126162  | 0.0000003047053982291667    | 0.000000000775701  |       |      | Phe | 1    | 4            |      | 9.366988779521161   |     |         |         |
| 5   | 5   | 224705 |     |     |     |        | 0.000665 | -40.591202 | 257.7320 | 2.53    | 9.07    | 0.0   | 8.550   | 1.494  | G8III        | 0.902  | 195.714261 | 0.034068 | -167.695291 | 0.00000737  | 0.00000316  | 0.00000861  | 0.000174033325628533    | -0.70845012723975    | 0.000000012265786118055555  | 0.0000000439726    |       |      | Phe | 1    | 5            |      | 21.998851090492494  |     |         |         |
| 6   | 6   |        |     |     |     |        | 0.001246 | 3.946458   | 55.0358  | 226.29  | -12.84  | 0.0   | 12.310  | 8.607  | M0V:         | 1.336  | 54.905296  | 0.017912 | 3.787796    | 0.00000022  | 0.00006037  | -0.00000342 | 0.0003262244926801302   | 0.068878680311835    | 0.0000010970848777291668    | -0.000000062250076 |       |      |     | 1    | 6            |      | 0.03141955284641073 |     | 12.462  | 12.162  |
| 7   | 7   |        |     |     |     |        | 0.001470 | 20.036114  | 57.8704  | -208.12 | -200.79 | 0.0   | 9.640   | 5.828  | G0           | 0.740  | 54.367897  | 0.020886 | 19.827115   | 0.00001932  | -0.00005838 | -0.00005292 | 0.00038472330047024304  | 0.3496961602478462   | -0.0000010089942319722222   | -0.000000973457389 |       |      | Peg | 1    | 7            |      | 0.4062561981868433  |     |         |         |
| 8   | 8   | 224709 |     |     |     |        | 0.001823 | 25.886461  | 200.8032 | 19.09   | -5.66   | -31.0 | 9.050   | 2.536  | M6e-M8.5e Tc | 1.102  | 180.654532 | 0.086213 | 87.668389   | -0.00002613 | 0.00001857  | -0.00001880 | 0.000477137820651658    | 0.4518039698960275   | 0.00000009255093161805554   | -0.000000027440454 |       |      | Peg | 1    | 8            |      | 8.425583753398259   | Z   | 11.748  | 7.648   |
| 9   | 9   | 224708 |     |     |     |        | 0.002355 | 36.585958  | 420.1681 | -6.30   | 8.42    | 0.0   | 8.590   | 0.473  | G5           | 1.067  | 337.379614 | 0.207994 | 250.431996  | -0.00001021 | -0.00001284 | 0.00001377  | 0.0006165627464585937   | 0.6385454301864713   | -0.000000030543261875       | 0.000000040821311  |       |      | And | 1    | 9            |      | 56.33781508509383   |     |         |         |



Almost all position values are measured at Epoch J2000 (some are from 1950)
Index,Key,Description,Data Type,Unit
0,id,HYG Database ID,int
1,hip,Hipparcos Catalog ID,int
2,hd,Henry Draper Catalog ID,int
3,hr,Harvard Revised / Yale Bright Star Catalog ID,int
4,gl,Gliese Catalog v3 ID,int
5,bf,Bayer / Flamsteed designation,string
6,proper,Common Name ie 'Sol',string
7,ra,Right Ascension,float,degrees
8,dec,Declination,float,degrees
9,dist,Distance from earth,float,parsecs
10,pmra,Proper Motion Right Ascension,float,milliarcseconds/year
11,pmdec,Proper Motion Declination,float,milliarcseconds/year
12,rv,Radial Velocity,float,km/sec
13,mag,Apparent visual magnitude,float
14,absmag,Absolute visual magnitude from distance of 10 parsecs,float
15,spect,Spectral type,string
16,ci,Color Index,float
17,x,Cartesian X Position - Vernal Equinox,float,parsecs
18,y,Cartesian Y Position - R.A. 6 hours; dec 0 degrees,float,parsecs
19,z,Cartesian Z Position - North Celestial Pole,float,parsecs
20,vx,Cartesian X Velocity - Vernal Equinox,float,parsecs/year
21,vy,Cartesian Y Velocity - R.A. 6 hours; dec 0 degrees,float,parsecs/year
22,vz,Cartesian Z Velocity - North Celestial Pole,float,parsecs/year
23,rarad,Right Ascension,float,radians
24,decrad,Declination,float,radians
25,pmrarad,Proper Motion Right Ascension,float,radians/year
26,pmdecrad,Proper Motion Declination,float,radians/year
27,bayer,Bayer Designation,string
28,flam,Flamsteed Designation,string
29,con,Standard Constellation Abbreviation,string
30,comp,multi-star system Companion Star ID,int
31,comp_primary,multi-star system Primary Star ID,int
32,base,multi-star system Catalog ID,int
33,lum,Luminosity,float,Solar Luminosity
34,var,Variable Star Designation,string
35,var_min,Variable Star Minimum Magnitude,float
36,var_max,Variable Star Maximum Magnitude,float
