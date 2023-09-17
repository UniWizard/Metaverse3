﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Mumble
{
    /// <summary>
    /// Decoding buffers include an opus decoder, which can be expensive to create
    /// If done frequently. So we have a pool of Decoding buffers that we re-use.
    /// </summary>
    public class DecodingBufferPool : IDisposable{

        private readonly Stack<AudioDecodingBuffer> _audioDecodingBuffers = new Stack<AudioDecodingBuffer>();
        private readonly int _outputSampleRate;
        private readonly int _outputChannelCount;

        public DecodingBufferPool(int rate, int channelCount)
        {
            _outputSampleRate = rate;
            _outputChannelCount = channelCount;
        }

        public AudioDecodingBuffer GetDecodingBuffer()
        {
            AudioDecodingBuffer decodingBuffer;
            if(_audioDecodingBuffers.Count != 0)
                decodingBuffer = _audioDecodingBuffers.Pop();
            else
                decodingBuffer = new AudioDecodingBuffer(_outputSampleRate, _outputChannelCount);
            return decodingBuffer;
        }

        public void ReturnDecodingBuffer(AudioDecodingBuffer decodingBuffer)
        {
            decodingBuffer.Reset();
            _audioDecodingBuffers.Push(decodingBuffer);
        }

        // Dispose of all buffers that are currently in use
        public void Dispose()
        {
            while(_audioDecodingBuffers.Count != 0)
            {
                AudioDecodingBuffer decodingBuffer = _audioDecodingBuffers.Pop();
                decodingBuffer.Dispose();
            }
        }
    }
}