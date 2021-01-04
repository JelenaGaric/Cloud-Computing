Vagrant.configure("2") do |config| 
  
  config.vm.provider "virtualbox" do |v|
    v.name = "Cloud-Computing-Vagrant"
  end
  
  config.vm.provider :virtualbox do |v|
    v.customize ["modifyvm", :id, "--memory", 2048]
  end
  
  config.vm.box = "hashicorp/bionic64"

  config.vm.network "forwarded_port", guest: 8080, host: 8080

  config.vm.provision "file", source: "Cloud-Computing", destination: "Cloud-Computing"
  config.vm.provision "file", source: "nginx", destination: "nginx"  
  config.vm.provision "file", source: "docker-compose.yaml", destination: "docker-compose.yaml"  
  config.vm.provision "file", source: "sapassword.env", destination: "sapassword.env"  
  config.vm.provision "file", source: "sqlserver.env", destination: "sqlserver.env"  
  
  config.vm.provision :shell, path: "docker.sh"
end
