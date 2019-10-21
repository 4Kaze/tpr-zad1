
person_obj = ("Person", 'new Person(1, "Stan", "Peacock", "Michelles 42")')
author_obj = ("Author", 'new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))')
catalog_obj = ("Catalog", 'new Catalog(1, "Pride and Prejudice", "This is description", {})'.format(author_obj[1]))
state_obj = ("StateDescription", 'new StateDescription(1, {}, System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here")'.format(catalog_obj[1]))
event_obj = ("Event", 'new Event(1, {}, {}, System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null))'.format(person_obj[1], state_obj[1]))

objects = [person_obj, author_obj, catalog_obj, state_obj, event_obj]

names = [("Person", "Person"),("Catalog","Catalog"),("StateDescription", "StateDescription"),("Transaction", "Event")]
def getInstantiation(name):
    return next(filter(lambda obj: obj[0] == name, objects))[1]


#0 - common class name, 1 - actual class name, 2 - instance name, 3 - object instantiation
test_add =  """[TestMethod]
            public void Repository{0}CRUDTest()
            {{
            \tDataRepository repository = new DataRepository();
            \t{1} {2} = {3};
            \trepository.Add{0}({2});
            \tAssert.AreEqual({2}, repository.Get{0}(0));
            \tAssert.AreEqual({2}, repository.Get{0}ByCode({2}.Code));

            \tIEnumerator<object> enumerator = repository.GetAll{0}s().GetEnumerator();
            \tenumerator.MoveNext();
            \tAssert.AreEqual({2}, enumerator.Current);

            \tint count = 0;
            \tenumerator = repository.GetAll{0}s().GetEnumerator();
            \twhile (enumerator.MoveNext()) count++;
            \tAssert.AreEqual(1, count);

            \t{1} {2}2 = {3};
            \t{2}2.Code = 2;
            \trepository.Update{0}(0, {2}2);
            \tAssert.AreEqual({2}2, repository.Get{0}(0));

            \t{2}2.Name = "test";
            \trepository.Update{0}({2}2);
            \tAssert.AreEqual("test", repository.Get{0}(0).Name);

            \tcount = 0;
            \tenumerator = repository.GetAll{0}s().GetEnumerator();
            \twhile (enumerator.MoveNext()) count++;
            \tAssert.AreEqual(1, count);
            \trepository.Add{0}({2});

            \tcount = 0;
            \tenumerator = repository.GetAll{0}s().GetEnumerator();
            \twhile (enumerator.MoveNext()) count++;
            \tAssert.AreEqual(2, count);
            \trepository.Delete{0}({2});

            \tcount = 0;
            \tenumerator = repository.GetAll{0}s().GetEnumerator();
            \twhile (enumerator.MoveNext()) count++;
            \tAssert.AreEqual(1, count);

            \trepository.Delete{0}ByIndex(0);
            \tcount = 0;
            \tenumerator = repository.GetAll{0}s().GetEnumerator();
            \twhile (enumerator.MoveNext()) count++;
            \tAssert.AreEqual(0, count);
            }}""";

test_multiple = """[TestMethod]
       public void Repository{0}MultipleItemsTest()
       {{
           DataRepository dr = new DataRepository();
           List<{1}> {2}s = new List<{1}>();
           for(int i = 0; i < 100; i++)
           {{
               {1} {2} = {3};
               {2}s.Add({2});
               dr.Add{0}({2});
           }}
           for(int i = 0; i < 100; i++)
           {{
               Assert.AreEqual({2}s[i], dr.Get{0}(i));
           }}

           for (int i = 0; i < 100; i++)
           {{
               Assert.AreEqual({2}s[i], dr.Get{0}ByCode({2}s[i].Code));
           }}

           int count1 = 0;
           List<{1}> {2}sToRemove = new List<{1}>();
           for (int i = 0; i < 100; i += 9)
           {{
               {2}sToRemove.Add({2}s[i]);
           }}

           foreach({1} p in {2}sToRemove)
           {{
               count1 += 1;
               {2}s.Remove(p);
               Assert.AreEqual(1, dr.Delete{0}(p));
           }}

           foreach({1} p in {2}s)
           {{
               Assert.IsNotNull(dr.Get{0}ByCode(p.Code));
           }}

           int count2 = 0;
           IEnumerator<{1}> enumerator = dr.GetAll{0}s().GetEnumerator();
           while (enumerator.MoveNext()) count2++;
           Assert.AreEqual(100-count1, count2);

           List<int> indexesToRemove = new List<int>();

           for (int i = 0; i < count2; i += 8)
           {{
               indexesToRemove.Add(i);
           }}

           int count3 = 0;
           foreach(int index in indexesToRemove)
           {{
               count1 += 1;
               {2}s.RemoveAt(index - count3);
               Assert.AreEqual(1, dr.Delete{0}ByIndex(index - count3));
               count3 += 1;
           }}

           foreach ({1} p in {2}s)
           {{
               Assert.IsNotNull(dr.Get{0}ByCode(p.Code));
           }}

           count2 = 0;
           enumerator = dr.GetAll{0}s().GetEnumerator();
           while (enumerator.MoveNext()) count2++;
           Assert.AreEqual(100 - count1, count2);
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
    print(generateTest(test_equals, name[0], name[1]))
