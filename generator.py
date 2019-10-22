
person_obj = ("Person", 'new Person("Stan", "Peacock", "Michelles 42")')
author_obj = ("Author", 'new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))')
catalog_obj = ("Catalog", 'new Catalog("Pride and Prejudice", "This is description", {})'.format(author_obj[1]))
state_obj = ("StateDescription", 'new StateDescription({}, System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here")'.format(catalog_obj[1]))
event_obj = ("Event", 'new Event({}, {}, System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null))'.format(person_obj[1], state_obj[1]))

objects = [person_obj, author_obj, catalog_obj, state_obj, event_obj]

names = [("Person", "Person"),("Catalog","Catalog"),("StateDescription", "StateDescription"),("Transaction", "Event")]
def getInstantiation(name):
    return next(filter(lambda obj: obj[0] == name, objects))[1]


#0 - common class name, 1 - actual class name, 2 - instance name, 3 - object instantiation
test_add =  """        [TestMethod]
        public void Repository{0}EnumeratorTest()
        {{
            DataRepository repository = new DataRepository();
            {1} {2} = {3};
            repository.Add{0}({2});

            int count = 0;
            IEnumerator<object> enumerator = repository.GetAll{0}s().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            {1} {2}2 = {3};
            repository.Add{0}({2}2);

            count = 0;
            enumerator = repository.GetAll{0}s().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(2, count);
        }}

        [TestMethod]
        public void Respository{0}ADDTest()
        {{
            DataRepository repository = new DataRepository();
            {1} {2} = {3};
            repository.Add{0}({2});
            Assert.AreEqual({2}, repository.Get{0}ByCode({2}.Code));

            IEnumerator<object> enumerator = repository.GetAll{0}s().GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual({2}, enumerator.Current);

            int count = 0;
            enumerator = repository.GetAll{0}s().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);
        }}

        [TestMethod]
        public void Repository{0}UPDATETest()
        {{
            DataRepository repository = new DataRepository();
            {1} {2} = {3};
            repository.Add{0}({2});

            {1} {2}2 = {3};
            {2}2.Code = {2}.Code;
            repository.Update{0}({2}2);

            Assert.AreEqual({2}2, repository.Get{0}ByCode({2}2.Code));

            {1} {2}3 = {3};
            {2}3.Code = {2}.Code;
            {2}3.Name = "test";

            repository.Update{0}({2}3);
            Assert.AreEqual("test", repository.Get{0}ByCode({2}.Code).Name);
        }}

        [TestMethod]
        public void Repository{0}DELTETest()
        {{
            DataRepository repository = new DataRepository();
            {1} {2} = {3};
            repository.Add{0}({2});
            repository.Delete{0}({2});

            int count = 0;
            IEnumerator<object> enumerator = repository.GetAll{0}s().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(0, count);
        }}"""

test_multiple = """        [TestMethod]
        public void Repository{0}AddMultipleTest()
        {{
            DataRepository dr = new DataRepository();
            List<{1}> {2}s = new List<{1}>();

            for (int i = 0; i < 100; i++)
            {{
                {1} {2} = {3};
                {2}s.Add({2});
                dr.Add{0}({2});
            }}

            for (int i = 0; i < 100; i++)
            {{
                Assert.AreEqual({2}s[i], dr.Get{0}ByCode({2}s[i].Code));
            }}

            int count = 0;
            IEnumerator<{1}> enumerator = dr.GetAll{0}s().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(100, count);
        }}

        [TestMethod]
        public void Repository{0}DeleteMultipleTest()
        {{
            DataRepository dr = new DataRepository();
            List<{1}> {2}sToRemove = new List<{1}>();

            for (int i = 0; i < 100; i++)
            {{
                {1} {2} = new {1}();
                if(i % 9 == 0) {2}sToRemove.Add({2});
                dr.Add{0}({2});
            }}

            int count = 0;
            foreach ({1} {2} in {2}sToRemove)
            {{
                count += 1;
                dr.Delete{0}({2});
            }}

            foreach ({1} {2} in {2}sToRemove)
            {{
                Assert.IsNull(dr.Get{0}ByCode({2}.Code));
            }}

            int count2 = 0;
            IEnumerator<{1}> enumerator = dr.GetAll{0}s().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count, count2);
        }}

        [TestMethod]
        public void Repository{0}UpdateMultipleTest()
        {{
            DataRepository dr = new DataRepository();
            List<{1}> {2}sToUpdate = new List<{1}>();

            for (int i = 0; i < 100; i++)
            {{
                {1} {2} = new {1}();
                if (i % 8 == 0) {2}sToUpdate.Add({2});
                dr.Add{0}({2});
            }}

            int count = 0;
            foreach ({1} {2} in {2}sToUpdate)
            {{
                count += 1;
                {2}.Name = "test " + count;
                dr.Update{0}({2});
            }}

            foreach ({1} {2} in {2}sToUpdate)
            {{
                Assert.AreEqual({2}.Name, dr.Get{0}ByCode({2}.Code).Name);
            }}

            count = 0;
            IEnumerator<{1}> enumerator = dr.GetAll{0}s().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(100, count);
        }}"""

test_equals = """
        [TestMethod]
        public void Equals{1}MethodTest()
        {{
            {1} {2} = {3};
            {1} {2}2 = {3};
            {2}2.Code = 2;
            Assert.AreNotEqual({2}, {2}2);

            {1} {2}3 = {3};
            Assert.AreEqual({2}, {2}3);
        }}"""
def PascalCase(text):
    return text[0].upper() + text[1:]

def camelCase(text):
    return text[0].lower() + text[1:]

def generateTest(test, commonClassName, className):
    return test.format(PascalCase(commonClassName), PascalCase(className), camelCase(commonClassName), getInstantiation(PascalCase(className)))

for name in names:
    print(generateTest(test_multiple, name[0], name[1]))
