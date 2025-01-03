﻿using System.Drawing;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TagsCloudVisualization.CircularCloudLayouters;
using TagsCloudVisualization.LayoutAlgorithms;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.Visualization;
using TagsCloudVisualizationTests.Utils;

namespace TagsCloudVisualizationTests;

[TestFixture]
public class CircularCloudLayoutTests
{
    private ICircularCloudLayouter cloudLayouter;
    private List<Rectangle> addedRectangles;
    
    [SetUp]
    public void Setup()
    {
        cloudLayouter =
            new CircularCloudLayouter(new CircularLayoutAlgorithm(new CircularLayoutAlgorithmSettings()));
        addedRectangles = [];
    }
    
    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed) 
            return;
        
        var pathImageStored = TestContext.CurrentContext.TestDirectory + @"\imageFailedTests";
    
        if (!Directory.Exists(pathImageStored))
        {
            Directory.CreateDirectory(pathImageStored);
        }
    
        var testName = TestContext.CurrentContext.Test.Name;
        
        var bitmap = ImageDrawerUtils.DrawLayout(addedRectangles, 10);
        
        var imageSaver = new ImageSaver(new ImageSaverSettings(pathImageStored, testName, "png"));
            
        imageSaver.Save(bitmap);
        
        Console.WriteLine($@"Tag cloud visualization saved to file {pathImageStored}\{testName}.png");
    }
    
    [TestCase(10, 5, 15)]
    [TestCase(50, 30, 100)]
    [TestCase(100, 5, 50)]
    public void PutNextRectangle_ShouldAddedRectanglesDoNotIntersect(int countRectangles, int minSideLength,
        int maxSideLength)
    {
        var rectangleSizes = GeometryUtils.GenerateRectangleSizes(countRectangles, minSideLength, maxSideLength);
        
        addedRectangles.AddRange(rectangleSizes.Select(t => cloudLayouter.PutNextRectangle(t)));

        for (var i = 0; i < addedRectangles.Count-1; i++)
        {
            addedRectangles
                .Skip(i + 1)
                .Any(addedRectangle => addedRectangle.IntersectsWith(addedRectangles[i]))
                .Should()
                .BeFalse();
        }
    }
    
    [TestCase(10, 5, 15)]
    [TestCase(50, 30, 100)]
    [TestCase(100, 5, 50)]
    public void CircleShape_ShouldBeCloseToCircle_WhenAddMultipleRectangles(int countRectangles, int minSideLength, 
        int maxSideLength)
    {
        var rectangleSizes = GeometryUtils.GenerateRectangleSizes(countRectangles, minSideLength, maxSideLength);
        
        addedRectangles.AddRange(rectangleSizes.Select(t => cloudLayouter.PutNextRectangle(t)));

        var distances = addedRectangles
            .Select(rectangle => 
                GeometryUtils.CalculateDistanceBetweenCenterRectangleAndCenterCloud(rectangle, new Point(0, 0)))
            .ToArray();

        for (var i = 1; i < distances.Length; i++)
        {
            var distanceBetweenRectangles =
                GeometryUtils.CalculateDistanceBetweenRectangles(addedRectangles[i], addedRectangles[i - 1]);
            distances[i].Should().BeApproximately(distances[i - 1], distanceBetweenRectangles);
        }
    }
}