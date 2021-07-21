using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace SfNestedsListView
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private ObservableCollection<Block> _blocks;
        public ObservableCollection<Block> Blocks
        {
            get => _blocks;
            set
            {
                _blocks = value;
                RaiseOnPropertyChanged();
            }
        }

        private Block _selectedBlock;
        public Block SelectedBlock
        {
            get => _selectedBlock;
            set
            {
                _selectedBlock = value;
                RaiseOnPropertyChanged();
                Blocks.Select(x => { x.IsSelected = false; return x; }).ToList();
                SelectedBlock.IsSelected = true;
            }
        }

        private Button _buttonSelected;
        public Button ButtonSelected
        {
            get => _buttonSelected;
            set
            {
                _buttonSelected = value;
                RaiseOnPropertyChanged();
                if(ButtonSelected != null)
                {
                    WidthSelectedButton = ButtonSelected.Width;
                }
            }
        }        
        
        private double _widthSelectedButton;
        public double WidthSelectedButton
        {
            get => _widthSelectedButton;
            set
            {
                _widthSelectedButton = value;
                RaiseOnPropertyChanged();
                UpdateSelectedButtonWidth();
            }
        }

        public ICommand AddButtonToSelectedBlockCommand => new Command(() => AddButtonToSelectedBlock());

        public ICommand SelectButtonCommand => new Command<Button>((btn) => SelectButton(btn));

        public ICommand UpdateSelectedButtonHeightCommand => new Command(() => UpdateSelectedButtonHeight());

        public ICommand AddNewBlockCommand => new Command(() => AddNewBlock());

        public MainViewModel()
        {
            Random rnd = new Random();

            Blocks = new ObservableCollection<Block>
            {
                new Block
                {
                    Name = "Block 1",
                    Height = rnd.Next(50, 100),
                    Buttons = new ObservableCollection<Button>
                    {
                        new Button
                        {
                            Name = "Button 1",
                            Height = rnd.Next(90, 270),
                            Width = 50,
                            Group = "0"
                        }
                    }
                },
                new Block
                {
                    Name = "Block 2",
                    Height = rnd.Next(50, 100),
                    Buttons = new ObservableCollection<Button>
                    {
                        new Button
                        {
                            Name = "Button 1",
                            Height = rnd.Next(90, 270),
                            Width = 50,
                            Group = "0"
                        }
                    }
                }
            };
            Blocks[0].IsSelected = true;
            SelectedBlock = Blocks[0];
            RefreshNestedListHeight();
        }

        private void AddButtonToSelectedBlock()
        {
            if (SelectedBlock != null)
            {
                Random rnd = new Random();
                var newButton = new Button
                {
                    Name = $"Button {SelectedBlock.Buttons.Count + 1}",
                    Height = rnd.Next(90, 270),
                    Width = rnd.Next(10, 100),
                    Group = "0"
                };

                SelectedBlock.Buttons.Add(newButton);
            }
        }

        private void SelectButton(Button button)
        {
            foreach (var block in Blocks)
            {
                foreach (var btn in block.Buttons)
                {
                    btn.IsSelected = false;
                }
            }
            button.IsSelected = true;
            ButtonSelected = button;
        }

        private void UpdateSelectedButtonHeight()
        {
            if (ButtonSelected != null)
            {
                ButtonSelected.Height = ButtonSelected.Height * 2;
            }
        }

        private void AddNewBlock()
        {
            Random rnd = new Random();

            var newBlock = new Block
            {
                Name = $"Block {Blocks.Count + 1}",
                Height = rnd.Next(50, 100),
                Buttons = new ObservableCollection<Button>
                {
                    new Button
                    {
                        Name = "Button 1",
                        Height = rnd.Next(90, 270),
                        Width = rnd.Next(10, 100),
                        Group = "0"
                    }
                }
            };
            Blocks.Add(newBlock);
        }

        public void RefreshNestedListHeight()
        {
            for (var i = 0; i < Blocks.Count; i++)
            {
                Blocks[i].NestedListHeight = Blocks[i].Buttons.Sum(x => x.Height);
            }
        }

        private void UpdateSelectedButtonWidth()
        {
            if(ButtonSelected != null)
            {
                ButtonSelected.Width = WidthSelectedButton;
            }
        }
    }
}