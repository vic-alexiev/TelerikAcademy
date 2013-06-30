var touristData = (function () {

    var locations = [
            {
                name: "Lisbon",
                latitude: 38.7,
                longitude: -9.167,
                info: "The capital of Portugal, Lisbon (Portuguese: Lisboa) has experienced a renaissance in \
                       recent years, with a contemporary culture that is alive and thriving and making its mark in \
                       today's Europe. Perched on the edge of the Atlantic Ocean, Lisbon is one of the rare \
                       Western European cities that face the ocean and uses water as an element that defines \
                       the city. Lisbon enchants travelers with its white bleached limestone buildings, intimate \
                       alleyways, and an easy going charm that makes it a popular year round destination."
            },
            {
                name: "Madrid",
                latitude: 40.417,
                longitude: -3.75,
                info: "Madrid is the capital and largest city of Spain, as well as the \
                       capital of the autonomous community of the same name (Comunidad de \
                       Madrid). The population of the city is roughly 3.3 million with a metro \
                       area population of almost 6.5 million. Madrid is best known for its great \
                       cultural and artistic heritage, a good example of which is the El Prado \
                       museum. Madrid also boasts some of the liveliest nightlife in the world."
            },
            {
                name: "London",
                latitude: 51.6,
                longitude: 0.083,
                info: "Noisy, vibrant and truly multicultural, London is a megalopolis of people, ideas and frenetic energy. \
                       The capital and largest city of both the United Kingdom and of England, it is also the largest city in \
                       Western Europe and the European Union. Situated on the River Thames in South-East England, \
                       Greater London has an official population of a little over 8 million — although the figure of 14 million \
                       for the city's metropolitan area more accurately reflects its size and importance. Considered one of \
                       two of the world's leading \"global cities\", London remains an international capital of culture, music, \
                       education, fashion, politics, finance and trade."
            },
            {
                name: "Paris",
                latitude: 48.833,
                longitude: 2.333,
                info: "Paris, the cosmopolitan capital of France, is - with 2.2 million people living in the dense (105 km²) central city and almost 12 \
                       million people living in the whole metropolitan area - one of the largest agglomerations in Europe. Located in the north of the \
                       country on the river Seine, Paris has the reputation of being the most beautiful and romantic of all cities, brimming with \
                       historic associations and remaining vastly influential in the realms of culture, art, fashion, food and design. Dubbed the City \
                       of Light (la Ville Lumière) and Capital of Fashion, it is home to the world's finest and most luxurious fashion designers and \
                       cosmetics, such as Chanel No.5, Christian Dior, Yves Saint-Laurent, Guerlain, Lancôme, L'Oréal, Clarins, etc. A large part \
                       of the city, including the River Seine, is a UNESCO World Heritage Site. The city has the second highest number of \
                       Michelin-restaurants in the world (after Tokyo) and contains numerous iconic landmarks, such as the world's most visited \
                       tourist site the Eiffel Tower, the Arc de Triomphe, the Notre-Dame Cathedral, the Louvre Museum, Moulin Rouge, Lido etc, \
                       making it the most popular tourist destination in the world with 45 million tourists annually."
            },
            {
                name: "Brussels",
                latitude: 50.85,
                longitude: 4.35,
                info: "Brussels (French: Bruxelles, Dutch: Brussel) is the capital city of Belgium and of \
                       Brussels Capital Region. It is entirely surrounded by Dutch-speaking Flanders and its \
                       constituent Flemish Brabant province. As headquarters of many European institutions, \
                       Brussels might also be considered something of a capital for the European Union. Being at the \
                       crossroads of cultures (the Germanic in the North and the Romance in the South) and playing \
                       an important role in Europe, Brussels fits the definition of the archetypal \"melting pot\", but still \
                       retains its own unique character. The population of the city of Brussels is 1 million and the \
                       population of Brussels metropolitan area is just over 2 million."
            },
            {
                name: "Amsterdam",
                latitude: 52.383,
                longitude: 4.9,
                info: "Amsterdam is the capital of the Netherlands. With more \
                       than one million inhabitants in its urban area, it is the country's \
                       largest city and its financial, cultural, and creative centre. \
                       Amsterdam is colloquially known as Venice of the North, \
                       because of its lovely canals that criss-cross the city, its \
                       impressive architecture and more than 1,500 bridges. There is \
                       something for every traveller's taste here, whether \
                       you prefer culture and history, serious partying, or just the relaxing charm \
                       of an old European city."
            },
            {
                name: "Rome",
                latitude: 41.9,
                longitude: 12.483,
                info: "Rome (Italian: Roma), the Eternal City, is the capital and largest city of Italy and of the Lazio \
                       (Latium) region. It's the famed city of the Roman Empire, the Seven Hills, La Dolce Vita (the sweet \
                       life), the Vatican City and Three Coins in the Fountain. Rome, as a millenium-long centre of power, \
                       culture and religion, having been the centre of one of the globe's greatest civilizations ever, has \
                       exerted a huge influence over the world in its c. 2500 years of existence.\
                       The Historic Centre of the city is a UNESCO World Heritage Site. With wonderful palaces, millenium-\
                       old churches and basilicas, grand romantic ruins, opulent monuments, ornate statues and graceful \
                       fountains, Rome has an immensely rich historical heritage and cosmopolitan atmosphere, making it \
                       one of Europe's and the world's most visited, famous, influential and beautiful capitals. Today, Rome \
                       has a growing nightlife scene and is also seen as a shopping heaven, being regarded as one of the \
                       fashion capitals of the world (some of Italy's oldest jewellery and clothing establishments were founded \
                       in the city). With so many sights and things to do, Rome can truly be classified a \"global city\"."
            },
            {
                name: "Prague",
                latitude: 50.083,
                longitude: 14.367,
                info: "Prague (Czech: Praha) is the capital city and largest city of the Czech Republic. It is one of the \
                       largest cities of Central Europe and has served as the capital of the historic region of Bohemia for \
                       centuries. \
                       This magical city of bridges, cathedrals, gold-tipped towers and church domes, has been mirrored in \
                       the surface of the swan-filled Vltava River for more than ten centuries. Almost undamaged by WWII, \
                       Prague's medieval centre remains a wonderful mixture of cobbled lanes, walled courtyards, cathedrals \
                       and countless church spires all in the shadow of her majestic 9th century castle that looks eastward \
                       as the sun sets behind her. Prague is also a modern and vibrant city full of energy, music, cultural art, \
                       fine dining and special events catering to the independent traveller's thirst for adventure.\
                       It is regarded by many as one of Europe's most charming and beautiful cities, Prague has become \
                       the most popular travel destination in Central Europe along with Bratislava and Krakow. Millions of \
                       tourists visit the city every year."
            },
            {
                name: "Vienna",
                latitude: 48.2,
                longitude: 16.367,
                info: "Vienna (German: Wien, Austro-Bavarian: Wean) is the capital of \
                       the Republic of Austria. It is by far the largest city in Austria, as well as \
                       its cultural, economic, and political centre. As the former home of the \
                       Habsburg court and its various empires, the city still has the trappings \
                       of the imperial capital it once was, and the historic city centre is \
                       inscribed on the UNESCO World Heritage List."
            },
            {
                name: "Budapest",
                latitude: 47.483,
                longitude: 19.083,
                info: "Budapest (Approx. Hungarian pronunciation: \"boo-dah-pesht\") [1] is the capital city of \
                       Hungary. With a unique, youthful atmosphere, world-class classical music scene as well as a \
                       pulsating nightlife increasingly appreciated among European youth, and last but not least, an \
                       exceptionally rich offer of natural thermal baths, Budapest is one of Europe's most delightful \
                       and enjoyable cities. Due to its scenic setting, and its architecture it is nicknamed \"Paris of the \
                       East\". In 1987 Budapest was added to the UNESCO World Heritage List for the cultural and \
                       architectural significance of the Banks of the Danube, the Buda Castle Quarter and Andrássy \
                       Avenue."
            }
    ];

    return {
        locations: locations
    };

})();