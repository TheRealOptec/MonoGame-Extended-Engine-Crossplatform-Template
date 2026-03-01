

// A test game which will be developed specifically to test and showcase the features of the MonoGame Extended Engine
//using var game = new MonoGame_Extended_Engine_Crossplatform_Template.Game1();
//game.Run();


using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Game_Objects;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Tags;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Pointers;
using System.Diagnostics;

StdGameObjectSpace testSpace = new();

IPointer<GameObject> obj1 = testSpace.CreateObject(x => x.AddTags(TagRegistry.TEST_1));
IPointer<GameObject> obj2 = testSpace.CreateObject(x => x.AddTags(TagRegistry.TEST_1));
IPointer<GameObject> obj3 = testSpace.CreateObject(x => x.AddTags(TagRegistry.TEST_2));

GameObject[] results1 = testSpace.GetObject(StdGameObjectSpaceFilter.FilterByTags(TagRegistry.TEST_1));
GameObject[] results2 = testSpace.GetObject(StdGameObjectSpaceFilter.FilterByTags(TagRegistry.TEST_2));

Debug.WriteLine("Results 1");
foreach (var g in results1) {
    Debug.WriteLine(g);
}

Debug.WriteLine("Results 2");
foreach (var g in results2) {
    Debug.WriteLine(g);
}
