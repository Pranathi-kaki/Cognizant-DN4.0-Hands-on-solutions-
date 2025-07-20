using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;

namespace KafkaChatApp
{
    public partial class Form1 : Form
    {
        private string bootstrapServers = "localhost:9092";
        private string topicName = "chat-topic";

        public Form1()
        {
            InitializeComponent();
            Task.Run(() => StartConsumer()); // Start listening in the background
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrWhiteSpace(message)) return;

            var config = new ProducerConfig { BootstrapServers = bootstrapServers };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                await producer.ProduceAsync(topicName, new Message<Null, string> { Value = message });
                txtChat.AppendText("Me: " + message + Environment.NewLine);
                txtMessage.Clear();
            }
        }

        private void StartConsumer()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe(topicName);

                try
                {
                    while (true)
                    {
                        var cr = consumer.Consume();
                        Invoke(new Action(() =>
                        {
                            txtChat.AppendText("Friend: " + cr.Message.Value + Environment.NewLine);
                        }));
                    }
                }
                catch (OperationCanceledException) { }
                finally
                {
                    consumer.Close();
                }
            }
        }
    }
}
