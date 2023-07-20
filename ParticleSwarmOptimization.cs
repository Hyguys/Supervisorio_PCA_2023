using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace ParticleSwarmOptimization
{
    public class Particle
    {
        public Vector<double> Position { get; set; }
        public Vector<double> Velocity { get; set; }
        public Vector<double> BestPosition { get; set; }
        public double BestFitness { get; set; }
    }

    public class ParticleSwarmOptimizer
    {
        private const int MaxIterations = 1000;
        private const int ParticleCount = 30;
        private const double InertiaWeight = 0.729;
        private const double CognitiveWeight = 1.49445;
        private const double SocialWeight = 1.49445;

        private readonly Random random = new Random();

        public Vector<double> FindMinimum(Func<Vector<double>, double> objectiveFunction, Vector<double> lowerBound, Vector<double> upperBound)
        {
            List<Particle> particles = InitializeParticles(lowerBound, upperBound);
            Vector<double> globalBestPosition = DenseVector.OfVector(particles[0].BestPosition);
            double globalBestFitness = particles[0].BestFitness;

            for (int iteration = 0; iteration < MaxIterations; iteration++)
            {
                foreach (var particle in particles)
                {
                    double fitness = objectiveFunction(particle.Position);

                    if (fitness < particle.BestFitness)
                    {
                        particle.BestPosition = DenseVector.OfVector(particle.Position);
                        particle.BestFitness = fitness;
                    }

                    if (fitness < globalBestFitness)
                    {
                        globalBestPosition = DenseVector.OfVector(particle.Position);
                        globalBestFitness = fitness;
                    }

                    UpdateVelocity(particle, globalBestPosition);
                    UpdatePosition(particle, lowerBound, upperBound);
                }
            }

            return globalBestPosition;
        }

        private List<Particle> InitializeParticles(Vector<double> lowerBound, Vector<double> upperBound)
        {
            List<Particle> particles = new List<Particle>();

            for (int i = 0; i < ParticleCount; i++)
            {
                Particle particle = new Particle
                {
                    Position = GenerateRandomVector(lowerBound, upperBound),
                    Velocity = GenerateRandomVector(lowerBound * -1, upperBound),
                };

                particle.BestPosition = DenseVector.OfVector(particle.Position);
                particle.BestFitness = double.MaxValue;

                particles.Add(particle);
            }

            return particles;
        }

        private Vector<double> GenerateRandomVector(Vector<double> lowerBound, Vector<double> upperBound)
        {
            double[] values = new double[lowerBound.Count];

            for (int i = 0; i < lowerBound.Count; i++)
            {
                values[i] = random.NextDouble() * (upperBound[i] - lowerBound[i]) + lowerBound[i];
            }

            return DenseVector.OfArray(values);
        }

        private void UpdateVelocity(Particle particle, Vector<double> globalBestPosition)
        {
            Vector<double> cognitiveComponent = CognitiveWeight * random.NextDouble() * (particle.BestPosition - particle.Position);
            Vector<double> socialComponent = SocialWeight * random.NextDouble() * (globalBestPosition - particle.Position);
            particle.Velocity = InertiaWeight * particle.Velocity + cognitiveComponent + socialComponent;
        }

        private void UpdatePosition(Particle particle, Vector<double> lowerBound, Vector<double> upperBound)
        {
            Vector<double> newPosition = particle.Position + particle.Velocity;

            for (int i = 0; i < newPosition.Count; i++)
            {
                if (newPosition[i] < lowerBound[i])
                    newPosition[i] = lowerBound[i];
                else if (newPosition[i] > upperBound[i])
                    newPosition[i] = upperBound[i];
            }

            particle.Position = newPosition;
        }
    }
}
